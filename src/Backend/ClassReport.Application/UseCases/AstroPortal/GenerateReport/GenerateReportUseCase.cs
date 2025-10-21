using System.Text.Json;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Domain.Services.OpenAI;

namespace MyRecipeBook.Application.UseCases.AstroPortal.GenerateReport;

public class GenerateReportUseCase :  IGenerateReportUseCase
{
    private readonly ITokenProvider _token;
    private readonly IGetBookIdAndDate _bookServiceId;
    private readonly IGetBookContent _bookServiceContent;
    private readonly IGenerateReportAi _aiService;
    private readonly IGetClasses _classService;
    private readonly IGetTeacherInfo _teacherService;
    public GenerateReportUseCase(ITokenProvider token, 
        IGetBookIdAndDate bookServiceId, 
        IGetBookContent bookServiceContent, 
        IGenerateReportAi aiService, IGetClasses classService, IGetTeacherInfo teacherService)
    {
        _token = token;
        _bookServiceId = bookServiceId;
        _bookServiceContent = bookServiceContent;
        _aiService = aiService;
        _classService = classService;
        _teacherService = teacherService;
    }
    public async Task<string> Execute(RequestClassId request)
    {
        var classId = request.ClassId;
        var accessToken = _token.Value();
        var dateToday = DateTime.Today.ToString("yyyy-MM-dd");
        var today = DateTime.Today.ToString("dddd").ToUpper();
        
        var book = await _bookServiceId.GetBookIdAndDate(accessToken, classId, dateToday, dateToday);
        var classes = await _classService.GetClassesToday(accessToken, today);
        var className = classes.Results.First(result => result.Id.ToString() == classId).Name;
        
        
        var teacher = await _teacherService.GetTeacherInfo(accessToken);
        var teacherName = teacher.FirstName + " " + teacher.LastName;
        
        
        var resultsProperty = book.RootElement.GetProperty("results");
        if (resultsProperty.ValueKind != JsonValueKind.Array || resultsProperty.GetArrayLength() == 0)
        {
            // Handle missing or empty results, e.g. throw a custom exception or return a meaningful message
            throw new InvalidOperationException("The 'results' array is missing or empty.");
        }

        var firstResult = resultsProperty[0];

        var bookId = firstResult
            .GetProperty("lesson")
            .GetProperty("book")
            .GetProperty("id").ToString();

        var lessonDate = firstResult
            .GetProperty("datetime").ToString();
        
        var response = await _bookServiceContent.GetBookContent(accessToken, bookId);

        var lessonContent = response.RootElement.ToString();

        var requestReport = new GenerateReportDto
        {
            LessonContent = lessonContent,
            LessonDate = lessonDate,
            LessonName = className,
            Teacher = teacherName
        };

        return await _aiService.Generate(requestReport);
    }
}