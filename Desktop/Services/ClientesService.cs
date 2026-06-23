using Desktop.Models;
using DotNetEnv;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Desktop.Services
{
    public class ClientesService
    {
        HttpClient httpClient;
        const string urlApi = "https://oyoilrybafmqmrcpydej.supabase.co/rest/v1/clientes"; // Endpoint

        public ClientesService()
        {
            Env.Load("../../../"); // Cargar las variables de entorno desde el archivo .env
            var apikey = Environment.GetEnvironmentVariable("apikey_supabase"); // Obtener la API key desde las variables de entorno

            // Inicializar el HttpClient y configurar la base address y los headers necesarios
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(urlApi);
            // agregar la apikey y el header de aceptacion de json
            httpClient.DefaultRequestHeaders.Add("apikey", apikey);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
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
                // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };

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
                // Configuramos las opciones de serialización para ignorar propiedades nulas y hacer que la búsqueda de propiedades sea insensible a mayúsculas
                var options = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                };

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
                var response = httpClient.DeleteAsync(urlDelete).Result;
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
    }
}
