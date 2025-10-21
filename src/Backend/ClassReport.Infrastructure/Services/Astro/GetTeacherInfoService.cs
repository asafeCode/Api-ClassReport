using System.Text.Json;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetTeacherInfoService :  IGetTeacherInfo
{
    private readonly ICtrlPlayClient _client;
    public GetTeacherInfoService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<JsonDocument> GetTeacherInfo(string accessToken)
    {
        var response = await _client.GetTeacherInfo(accessToken);
        var responseData = await JsonDocument.ParseAsync(response.Content!);
        
        return responseData;
    }
}