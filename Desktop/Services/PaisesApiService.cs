using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Models;

namespace Desktop.Services
{
    public class PaisesApiService
    {
        HttpClient httpClient;
        string urlApi; // Endpoint
        JsonSerializerOptions options;

        public PaisesApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Pais>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener los paises" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var paises = JsonSerializer.Deserialize<List<Pais>>(json, options);

                return paises;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener paises desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Pais>?> GetDeletedsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener los paises" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var pais = JsonSerializer.Deserialize<List<Pais>>(json, options);

                return pais;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener paises desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Pais>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al obtener los paises" + response.ReasonPhrase);
                }
                var json = await response.Content.ReadAsStringAsync();
                var pais = JsonSerializer.Deserialize<List<Pais>>(json, options);

                return pais;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener paises desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddPaisAsync(Pais pais)
        {
            try
            {
                var json = JsonSerializer.Serialize(pais, options);
                var paisJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", paisJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el pais desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdatePaisAsync(Pais pais)
        {
            try
            {
                var json = JsonSerializer.Serialize(pais, options);
                var paisJson = new StringContent(json, Encoding.UTF8, "application/json");
                string idPais = pais.Id.ToString();
                var response = await httpClient.PutAsync(idPais, paisJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar el pais: " + response.ReasonPhrase);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pais desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeletePaisAsync(int? id)
        {
            try
            {
                var response = await httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pais desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> RestorePaisAsync(int? id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al eliminar el pais: " + response.ReasonPhrase);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pais desde la Api: " + ex.Message);
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
            urlApi += "Paises/";
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
