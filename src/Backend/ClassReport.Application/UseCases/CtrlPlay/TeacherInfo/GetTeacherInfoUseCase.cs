using System.Text.Json;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.TeacherInfo;

public class GetTeacherInfoUseCase : IGetTeacherInfoUseCase
{
    private readonly IGetTeacherInfo _services;
    private readonly ITokenProvider _token;

    public GetTeacherInfoUseCase(IGetTeacherInfo services, ITokenProvider token)
    {
        _services = services;
        _token = token;
    }
    public async Task<JsonDocument> Execute()
    {
        var token = _token.Value();
        var teacher = await _services.GetTeacherInfo(token);
        
        return teacher;
    }
}