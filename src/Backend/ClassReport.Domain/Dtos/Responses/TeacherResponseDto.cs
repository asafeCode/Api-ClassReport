namespace MyRecipeBook.Domain.Dtos.Responses;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class TeacherResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("units_ids")]
    public List<int> UnitsIds { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("extra_email")]
    public string? ExtraEmail { get; set; }

    [JsonPropertyName("user_type")]
    public string UserType { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonPropertyName("last_login")]
    public DateTime LastLogin { get; set; }

    [JsonPropertyName("profile")]
    public TeacherProfileDto Profile { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }
}
