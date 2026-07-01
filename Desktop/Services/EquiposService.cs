using Desktop.Models;
using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class EquiposService
    {

        HttpClient httpClient;
        string urlApi; // Endpoint
        JsonSerializerOptions options;

        public EquiposService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Equipo>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var equipos = JsonSerializer.Deserialize<List<Equipo>>(json);
                    return equipos;
                }
                else
                {
                    throw new Exception("Error al obtener los equipos" + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener equipos desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<List<Equipo>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                string filtrosupabase = $"?or=(marca.ilike.*{filter}*,modelo.ilike.*{filter}*)";
                var response = await httpClient.GetAsync(filtrosupabase);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var equipos = JsonSerializer.Deserialize<List<Equipo>>(json);
                    return equipos;
                }
                else
                {
                    throw new Exception("Error al obtener los equipos" + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener equipos desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async Task<bool> AddEquipoAsync(Equipo equipo)
        {
            try
            {
                var json = JsonSerializer.Serialize(equipo, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al crear el equipo: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el equipo desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateEquipoAsync(Equipo equipo)
        {
            try
            {
                var json = JsonSerializer.Serialize(equipo, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlUpdate = $"?id_equipo=eq.{equipo.id_equipo}";
                var response = await httpClient.PutAsync(urlUpdate, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el equipo: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el equipo desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteEquipoAsync(int? id)
        {
            try
            {
                string urlDelete = $"?id_equipo=eq.{id}";
                var response = httpClient.DeleteAsync(urlDelete).Result;
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el equipo: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el equipo desde la Api: " + ex.Message);
                return false;
            }
        }

        // Segunda refactorizaion
        private HttpClient SettingHttpClient()
        {
            Env.Load("../../../");
            urlApi = Environment.GetEnvironmentVariable("supabase_equipos_endpoint");
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
