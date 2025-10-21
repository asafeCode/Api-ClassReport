using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses;

public class ChatCompletionResponse
{
    [JsonPropertyName("choices")] 
    public List<Choice> Choices { get; set; } = [];
}