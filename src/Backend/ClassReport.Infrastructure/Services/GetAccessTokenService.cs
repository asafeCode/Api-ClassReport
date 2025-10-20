using System.Text.Json;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services;

public class GetAccessTokenService : IGetAccessToken
{
    private readonly ICtrlPlayClient _client;
    public GetAccessTokenService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<string> GetAccessToken(RequestLoginDto request)
    {
        var response = await _client.Login(request);
        if (response.IsSuccessful.IsFalse()) throw new ExternalServiceException(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID);
        var responseData = await JsonDocument.ParseAsync(response.Content!);
        var accessToken = responseData.RootElement.GetProperty("access").GetString();
        return accessToken!;
    }
}