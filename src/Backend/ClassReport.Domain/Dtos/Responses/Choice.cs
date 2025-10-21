using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses;

public class Choice
{
    [JsonPropertyName("message")] 
    public MessageDto Message { get; set; }
}