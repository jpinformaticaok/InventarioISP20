using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Models;

namespace Desktop.Services
{
    public class LocalidadesApiService
    {
        HttpClient httpClient;
        string urlApi; // Endpoint
        JsonSerializerOptions options;

        public LocalidadesApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Localidad>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener las localidades" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var localidades = JsonSerializer.Deserialize<List<Localidad>>(json, options);

                return localidades;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener localidades desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Localidad>?> GetDeletedsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener las localidades" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var localidad = JsonSerializer.Deserialize<List<Localidad>>(json, options);

                return localidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener localidades desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Localidad>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener las localidades" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var localidad = JsonSerializer.Deserialize<List<Localidad>>(json, options);

                return localidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener localidades desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddLocalidadAsync(Localidad localidad)
        {
            try
            {
                var json = JsonSerializer.Serialize(localidad, options);
                var localidadJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", localidadJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la localidad desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateLocalidadAsync(Localidad localidad)
        {
            try
            {
                var json = JsonSerializer.Serialize(localidad, options);
                var localidadJson = new StringContent(json, Encoding.UTF8, "application/json");
                string idLocalidad = localidad.Id.ToString();
                var response = await httpClient.PutAsync(idLocalidad, localidadJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar la localidad: " + response.ReasonPhrase);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la localidad desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteLocalidadAsync(int? id)
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la localidad desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RestoreLocalidadAsync(int? id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la localidad: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la localidad desde la Api: " + ex.Message);
                return false;
            }
        }

        // Segunda refactorizaion
        private HttpClient SettingHttpClient()
        {
            Env.Load("../../../");
            //URLAPI remoto, URLLOCAL local
            //urlApi = Environment.GetEnvironmentVariable("URLAPI");
            urlApi = Environment.GetEnvironmentVariable("URLAPILOCAL");
            urlApi += "Localidades/";
            //instanciamos el httpClient y lo configuramos para poder utilizarlo en cada uno de los métodos
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("apikey", urlApi);
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
