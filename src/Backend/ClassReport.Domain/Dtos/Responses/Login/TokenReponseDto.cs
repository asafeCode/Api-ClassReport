using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.Login;

public class TokenReponseDto
{
    [JsonPropertyName("access")] 
    public string Access { get; set; } = string.Empty;
}