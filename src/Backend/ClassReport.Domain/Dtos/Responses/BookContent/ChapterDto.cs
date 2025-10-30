using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.BookContent;

public class ChapterDto
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }
}