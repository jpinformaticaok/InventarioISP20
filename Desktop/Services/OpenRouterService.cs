using Desktop.Models;
using System.Text.Json;

namespace Desktop.Services
{
    public static class OpenRouterService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<OpenRouterModel>> GetFreeModelsAsync()
        {
            var response = await client.GetAsync("https://openrouter.ai/api/v1/models");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var parsed = JsonSerializer.Deserialize<OpenRouterResponse>(json, options);

            return parsed.Data
                .Where(m => m.Pricing != null
                         && m.Pricing.Prompt == "0"
                         && m.Pricing.Completion == "0")
                .OrderBy(m => m.Name)
                .ToList();
        }
    }
}
