using System.Text.Json;
using System.Text.Json.Serialization;

namespace Services.Models
{
    public class OpenRouterResponse
    {
        [JsonPropertyName("data")]
        public List<OpenRouterModel> Data { get; set; }
    }

    public class OpenRouterModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("context_length")]
        public int? ContextLength { get; set; }

        [JsonPropertyName("pricing")]
        public OpenRouterPricing Pricing { get; set; }

        public override string ToString() => Name; // esto es lo que se ve en el ComboBox
    }

    public class OpenRouterPricing
    {
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("completion")]
        public string Completion { get; set; }
    }

    // ===========================================================================
    // Aca empieza todo lo relacionado con el manejo de la respuesta de OpenRouter
    // ===========================================================================

    public class ChatCompletionResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("choices")]
        public List<ChatChoice> Choices { get; set; }

        [JsonPropertyName("usage")]
        public ChatUsage Usage { get; set; }

        [JsonPropertyName("error")]
        public ChatError Error { get; set; }
    }

    public class ChatChoice
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("message")]
        public ChatMessage Message { get; set; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }
    }

    public class ChatMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class ChatUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int CompletionTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }

    public class ChatError
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }

    public class OpenRouterResult
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        public string ModelUsed { get; private set; }
        public string AnswerText { get; private set; }
        public string FinishReason { get; private set; }

        public int PromptTokens { get; private set; }
        public int CompletionTokens { get; private set; }
        public int TotalTokens { get; private set; }

        private OpenRouterResult() { }

        public static OpenRouterResult Parse(string responseText)
        {
            var result = new OpenRouterResult();

            if (string.IsNullOrWhiteSpace(responseText))
            {
                result.Success = false;
                result.ErrorMessage = "La respuesta está vacía.";
                return result;
            }

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var parsed = JsonSerializer.Deserialize<ChatCompletionResponse>(responseText, options);

                if (parsed == null)
                {
                    result.Success = false;
                    result.ErrorMessage = "No se pudo interpretar la respuesta (JSON nulo).";
                    return result;
                }

                // Caso: la API devolvió un error (ej: modelo no disponible, rate limit, etc.)
                if (parsed.Error != null)
                {
                    result.Success = false;
                    result.ErrorMessage = $"[{parsed.Error.Code}] {parsed.Error.Message}";
                    return result;
                }

                // Caso: no vino ningún choice (respuesta inesperada)
                if (parsed.Choices == null || parsed.Choices.Count == 0)
                {
                    result.Success = false;
                    result.ErrorMessage = "La respuesta no contiene ningún resultado (choices vacío).";
                    return result;
                }

                var primeraRespuesta = parsed.Choices[0];

                result.Success = true;
                result.ModelUsed = parsed.Model;
                result.AnswerText = primeraRespuesta.Message?.Content?.Trim();
                result.FinishReason = primeraRespuesta.FinishReason;

                if (parsed.Usage != null)
                {
                    result.PromptTokens = parsed.Usage.PromptTokens;
                    result.CompletionTokens = parsed.Usage.CompletionTokens;
                    result.TotalTokens = parsed.Usage.TotalTokens;
                }

                return result;
            }
            catch (JsonException ex)
            {
                result.Success = false;
                result.ErrorMessage = $"Error al parsear el JSON: {ex.Message}";
                return result;
            }
        }

        public override string ToString()
        {
            if (!Success)
                return $"ERROR: {ErrorMessage}";

            return $"Modelo: {ModelUsed}\n" +
                   $"Motivo de fin: {FinishReason}\n" +
                   $"Tokens (prompt/completion/total): {PromptTokens}/{CompletionTokens}/{TotalTokens}\n" +
                   $"Respuesta: {AnswerText}";
        }
    }
}
