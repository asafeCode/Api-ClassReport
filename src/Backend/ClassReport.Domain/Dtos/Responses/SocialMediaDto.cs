using System.Text.Json.Serialization;

namespace MyRecipeBook.Domain.Dtos.Responses;

public class SocialMediaDto
{
    [JsonPropertyName("media_name")]
    public string MediaName { get; set; }

    [JsonPropertyName("media_url")]
    public string MediaUrl { get; set; }
}