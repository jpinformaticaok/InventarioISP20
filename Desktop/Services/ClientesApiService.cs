using DotNetEnv;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Services.Models;

namespace Desktop.Services
{
    public class ClientesApiService
    {
        HttpClient httpClient;
        string urlApi; // Endpoint
        JsonSerializerOptions options;

        public ClientesApiService()
        {
            httpClient = SettingHttpClient();
            options = SettingJsonSerializer();
        }

        public async Task<List<Cliente>?> GetAllAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(json, options);

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

        public async Task<List<Cliente>?> GetDeletedsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("deleteds");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(json, options);

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
                var response = await httpClient.GetAsync($"?filtro={filter}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(json, options);

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
                var clienteJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("", clienteJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al crear el cliente: " + response.ReasonPhrase);
                    return false;
                }
                return true;
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
                var clienteJson = new StringContent(json, Encoding.UTF8, "application/json");
                string idCliente = cliente.Id.ToString();
                var response = await httpClient.PutAsync(idCliente, clienteJson);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + response.ReasonPhrase);
                    return false;
                }

                return true;
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
                var response = await httpClient.DeleteAsync(id.ToString());
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

        public async Task<bool> RestoreClienteAsync(int? id)
        {
            try
            {
                var response = await httpClient.PutAsync($"restore/{id}", null);
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
            //URLAPI remoto, URLLOCAL local
            //urlApi = Environment.GetEnvironmentVariable("URLAPI");
            urlApi = Environment.GetEnvironmentVariable("URLAPILOCAL");
            urlApi += "Clientes/";
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
