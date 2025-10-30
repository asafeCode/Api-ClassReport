using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.BookId;

public class ScheduledLessonDto
{
    [JsonPropertyName("lesson")] 
    public LessonDto? Lesson { get; set; }
    
    [JsonPropertyName("datetime")] 
    public string DateTime { get; set; } = string.Empty;
    
    [JsonPropertyName("is_active")] 
    public bool IsActive { get; set; }
}
public class LessonDto
{
    [JsonPropertyName("book")] 
    public BookDto? Book { get; set; }
}
public class BookDto
{
    [JsonPropertyName("id")] 
    public int? Id { get; set; }
}