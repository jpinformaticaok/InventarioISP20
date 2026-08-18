using Desktop.Models;
using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class ClientesService
    {
        HttpClient httpClient;
        const string urlApi = "https://oyoilrybafmqmrcpydej.supabase.co/rest/v1/clientes"; // Endpoint
        JsonSerializerOptions options;

        public ClientesService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Cliente>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(urlApi);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = System.Text.Json.JsonSerializer.Deserialize<List<Models.Cliente>>(json);
                    return clientes;
                }
                else
                {
                    throw new Exception("Error al obtener los clientes" + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener clientes desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<List<Cliente>?> GetAllWithFilterAsync(string filter)
        {
            try
            {
                string filtrosupabase = $"?or=(firstname.ilike.*{filter}*,lastname.ilike.*{filter}*, dni.ilike.*{filter}*)";
                var response = await httpClient.GetAsync(filtrosupabase);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = System.Text.Json.JsonSerializer.Deserialize<List<Models.Cliente>>(json);
                    return clientes;
                }
                else
                {
                    throw new Exception("Error al obtener los clientes" + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener clientes desde la Api: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<bool> AddClienteAsync(Cliente cliente)
        {
            try
            {
                var json = JsonSerializer.Serialize(cliente, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al crear el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el cliente desde la Api: " + ex.Message);
                return false;
            }

        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            try
            {
                var json = JsonSerializer.Serialize(cliente, options);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string urlUpdate = $"?id=eq.{cliente.id}";
                var response = await httpClient.PutAsync(urlUpdate, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteClienteAsync(int? id)
        {
            try
            {
                string urlDelete = $"?id=eq.{id}";
                var response = await httpClient.DeleteAsync(urlDelete);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente: " + response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente desde la Api: " + ex.Message);
                return false;
            }
        }

        // Segunda refactorizaion
        private HttpClient SettingHttpClient()
        {
            Env.Load("../../../");
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
