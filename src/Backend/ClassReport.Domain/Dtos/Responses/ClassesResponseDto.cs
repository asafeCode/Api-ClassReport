using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses;

public class ClassesResponseDto
{
    [JsonPropertyName("results")] 
    public List<ClassDto> Results { get; set; } = [];
}


