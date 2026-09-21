using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Models;

namespace Desktop.Services
{
    public class ProvinciasApiService
    {
        HttpClient httpClient;
        string urlApi; // Endpoint
        JsonSerializerOptions options;

        public ProvinciasApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Provincia>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener las provincias" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var provincias = JsonSerializer.Deserialize<List<Provincia>>(json, options);

                return provincias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener provincias desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Provincia>?> GetDeletedsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener las provincias" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var provincia = JsonSerializer.Deserialize<List<Provincia>>(json, options);

                return provincia;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener provincias desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Provincia>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener las provincias" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var provincia = JsonSerializer.Deserialize<List<Provincia>>(json, options);

                return provincia;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener provincias desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddProvinciaAsync(Provincia provincia)
        {
            try
            {
                var json = JsonSerializer.Serialize(provincia, options);
                var provinciaJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", provinciaJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la provincia desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateProvinciaAsync(Provincia provincia)
        {
            try
            {
                var json = JsonSerializer.Serialize(provincia, options);
                var provinciaJson = new StringContent(json, Encoding.UTF8, "application/json");
                string idProvincia = provincia.Id.ToString();
                var response = await httpClient.PutAsync(idProvincia, provinciaJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar la provincia: " + response.ReasonPhrase);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la provincia desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteProvinciaAsync(int? id)
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la provincia desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RestoreProvinciaAsync(int? id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar la provincia: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la provincia desde la Api: " + ex.Message);
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
            urlApi += "Provincias/";
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
