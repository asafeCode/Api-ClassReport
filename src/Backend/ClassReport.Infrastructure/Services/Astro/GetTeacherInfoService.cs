using System.Runtime.InteropServices;
using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Infrastructure.Clients;
using Refit;

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
        if (response.IsSuccessStatusCode.IsFalse()) throw new ExternalException(ResourceMessagesException.NO_TOKEN);
        var responseContent = response.Content!;
        return responseContent;
    }
}