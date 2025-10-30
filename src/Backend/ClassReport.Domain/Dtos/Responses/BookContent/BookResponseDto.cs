using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.BookContent;

public class BookResponseDto
{
    [JsonPropertyName("chapters")]
    public List<ChapterDto>? Chapters { get; set; }
}


