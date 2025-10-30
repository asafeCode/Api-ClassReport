using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses.Teacher;

public class TeacherResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }
}
