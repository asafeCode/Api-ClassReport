using System.Text.Json;

namespace MyRecipeBook.Domain.Services.OpenAI;

public interface IGenerateReportAi
{
    Task<string> Generate(string lessonContent, string teacher, string lessonDate,
        string lessonName);
}