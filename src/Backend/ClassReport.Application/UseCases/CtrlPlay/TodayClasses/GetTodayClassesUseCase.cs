using System.Globalization;
using System.Text.Json;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.TodayClasses;

public class GetTodayClassesUseCase :  IGetTodayClassesUseCase
{
    private readonly ITokenProvider _token;
    private readonly IGetClasses _service;
    public GetTodayClassesUseCase(ITokenProvider token,
        IGetClasses service)
    {
        _token = token;
        _service = service;
    }

    public async Task<JsonDocument> Execute()
    {
        var token = _token.Value();
        var today = DateTime.Today.ToString("dddd").ToUpper();
        var classes = await _service.GetClassesToday(token, today);

        return classes;
    }
}