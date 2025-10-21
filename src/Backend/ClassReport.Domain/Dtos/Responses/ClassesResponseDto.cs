using System.Text.Json.Serialization;

public class DayTimeDto
{
    [JsonPropertyName("day")]
    public string Day { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }
}

public class ClassDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("unit_id")]
    public int UnitId { get; set; }

    [JsonPropertyName("teacher_id")]
    public int TeacherId { get; set; }

    [JsonPropertyName("course_path_slug")]
    public string CoursePathSlug { get; set; }

    [JsonPropertyName("course_path_id")]
    public int CoursePathId { get; set; }

    [JsonPropertyName("klass_start_date")]
    public DateTime KlassStartDate { get; set; }

    [JsonPropertyName("klass_end_date")]
    public DateTime KlassEndDate { get; set; }

    [JsonPropertyName("day_times")]
    public List<DayTimeDto> DayTimes { get; set; }

    [JsonPropertyName("class_room_url")]
    public string ClassRoomUrl { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    [JsonPropertyName("max_capacity")]
    public int MaxCapacity { get; set; }

    [JsonPropertyName("conecta_seats")]
    public int ConectaSeats { get; set; }

    [JsonPropertyName("klass_type")]
    public string KlassType { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("enrolls_count")]
    public int EnrollsCount { get; set; }
}

public class PaginationDto
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class MetaDto
{
    [JsonPropertyName("pagination")]
    public PaginationDto Pagination { get; set; }
}

public class LinksDto
{
    [JsonPropertyName("first")]
    public string First { get; set; }

    [JsonPropertyName("last")]
    public string Last { get; set; }

    [JsonPropertyName("next")]
    public string Next { get; set; }

    [JsonPropertyName("prev")]
    public string Prev { get; set; }
}

public class ClassesResponseDto
{
    [JsonPropertyName("results")]
    public List<ClassDto> Results { get; set; }

    [JsonPropertyName("meta")]
    public MetaDto Meta { get; set; }

    [JsonPropertyName("links")]
    public LinksDto Links { get; set; }
}
