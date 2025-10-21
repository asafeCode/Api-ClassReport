using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetTeacherInfoService :  IGetTeacherInfo
{
    private readonly ICtrlPlayClient _client;
    public GetTeacherInfoService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<TeacherResponseDto> GetTeacherInfo(string accessToken)
    {
        var response = await _client.GetTeacherInfo(accessToken);
        return response.Content!;
    }
}