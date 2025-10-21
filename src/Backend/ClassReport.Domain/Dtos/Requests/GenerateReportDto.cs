namespace MyRecipeBook.Domain.Dtos.Requests;

public record GenerateReportDto
{
    public string LessonContent = string.Empty;
    public string Teacher = string.Empty;
    public string LessonDate = string.Empty;
    public string LessonName =  string.Empty;
}