using System.Text.Json;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Domain.Services.OpenAI;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.GenerateReport;

public class GenerateReportUseCase :  IGenerateReportUseCase
{
    private readonly ITokenProvider _token;
    private readonly IGetBookIdAndDate _bookServiceId;
    private readonly IGetBookContent _bookServiceContent;
    private readonly IGenerateReportAi _aiService;
    public GenerateReportUseCase(ITokenProvider token, 
        IGetBookIdAndDate bookServiceId, 
        IGetBookContent bookServiceContent, 
        IGenerateReportAi aiService)
    {
        _token = token;
        _bookServiceId = bookServiceId;
        _bookServiceContent = bookServiceContent;
        _aiService = aiService;
    }
    public async Task<string> Execute(RequestClassId request)
    {
        var classId = request.ClassId;
        var accessToken = _token.Value();
        var dateToday = DateTime.Today.ToString("yyyy-MM-dd");
        var book = await _bookServiceId.GetBookIdAndDate(accessToken, classId, dateToday, dateToday);
        
        var bookId = book.RootElement
            .GetProperty("results")[0]
            .GetProperty("lesson")
            .GetProperty("book")
            .GetProperty("id").ToString();
        
        var lessonDate = book.RootElement
            .GetProperty("results")[0]
            .GetProperty("datetime").ToString();
        
        var response = await _bookServiceContent.GetBookContent(accessToken, bookId);

        var lessonContent = response.RootElement.ToString();

        return await _aiService.Generate(lessonContent, teacher: "Gabriel Barros", lessonDate: lessonDate, lessonName: "#7015 - CT3 / OUT / SEG / 18:30 / Gabriel Barros");
    }
}