using Desktop.Models;
using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class TiposEquiposService
    {

        HttpClient httpClient;
        string urlApi; // Endpoint
        JsonSerializerOptions options;

        public TiposEquiposService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<TipoEquipo>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var tipoEquipos = JsonSerializer.Deserialize<List<TipoEquipo>>(json);
                    return tipoEquipos;
                }
                else
                {
                    throw new Exception("Error al obtener los tipos de equipos" + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener tipos de equipos desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<List<TipoEquipo>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                string filtrosupabase = $"?or=(descripcion.ilike.*{filter}*)";
                var response = await httpClient.GetAsync(filtrosupabase);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var tipoequipos = JsonSerializer.Deserialize<List<TipoEquipo>>(json);
                    return tipoequipos;
                }
                else
                {
                    throw new Exception("Error al obtener los tipos de equipos" + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener tipos de equipos desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<bool> AddTipoEquipoAsync(TipoEquipo tipoEquipo)
        {
            try
            {
                var json = JsonSerializer.Serialize(tipoEquipo, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al crear el tipo de equipo: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el tipo de equipo desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateTipoEquipoAsync(TipoEquipo tipoEquipo)
        {
            try
            {
                var json = JsonSerializer.Serialize(tipoEquipo, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlUpdate = $"?id_tipo_equipo=eq.{tipoEquipo.id_tipo_equipo}";
                var response = await httpClient.PutAsync(urlUpdate, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el tipo de equipo: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el tipo de equipo desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteTipoEquipoAsync(long? id)
        {
            try
            {
                string urlDelete = $"?id_tipo_equipo=eq.{id}";
                var response = await httpClient.DeleteAsync(urlDelete);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        MessageBox.Show("No se puede eliminar el tipo de equipo porque está siendo utilizado por un equipo.");
                        return false;
                    }
                    else MessageBox.Show("Error al eliminar el tipo de equipo: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el tipo de equipo desde la Api: " + ex.Message);
                return false;
            }
        }

        // Segunda refactorizaion
        private HttpClient SettingHttpClient()
        {
            Env.Load("../../../");
            urlApi = Environment.GetEnvironmentVariable("supabase_tipos_equipos_endpoint");
            var apikey = Environment.GetEnvironmentVariable("apikey_supabase");
            //instanciamos el httpClient y lo configuramos para poder utilizarlo en cada uno de los métodos
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi);
            //agregamos apikey de la url
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("apikey", apikey);
            return httpClient;
        }

        private JsonSerializerOptions SettingJsonSerializer()
        {
            return new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNameCaseInsensitive = true,
            };
        }
    }
}
