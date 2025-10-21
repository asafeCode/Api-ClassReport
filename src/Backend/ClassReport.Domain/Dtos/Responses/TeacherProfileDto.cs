using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MyRecipeBook.Domain.Dtos.Responses;

public class TeacherProfileDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; set; }

    [JsonPropertyName("banner_url")]
    public string BannerUrl { get; set; }

    [JsonPropertyName("date_of_birth")]
    public DateTime DateOfBirth { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("social_media")]
    public List<SocialMediaDto> SocialMedia { get; set; }
}