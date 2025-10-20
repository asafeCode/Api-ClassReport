using System.Text.Json;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.GenerateReport;

public class GenerateReportUseCase :  IGenerateReportUseCase
{
    private readonly ITokenProvider _token;
    private readonly IGetBookIdAndDate _bookServiceId;
    private readonly IGetBookContent _bookServiceContent;
    public GenerateReportUseCase(ITokenProvider token, 
        IGetBookIdAndDate bookServiceId, 
        IGetBookContent bookServiceContent)
    {
        _token = token;
        _bookServiceId = bookServiceId;
        _bookServiceContent = bookServiceContent;
    }
    public async Task<JsonDocument> Execute(RequestClassId request)
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
        
        var bookContent = await _bookServiceContent.GetBookContent(accessToken, bookId);

        return bookContent;
    }
}