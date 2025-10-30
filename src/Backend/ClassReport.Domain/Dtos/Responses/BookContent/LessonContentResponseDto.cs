using System.Text.Json.Serialization;
using MyRecipeBook.Domain.Dtos.Responses.BookId;

namespace MyRecipeBook.Domain.Dtos.Responses.BookContent;

public class LessonContentResponseDto
{
    [JsonPropertyName("results")] 
    public List<BookResponseDto>? Results { get; set; } = [];
}