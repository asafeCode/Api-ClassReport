using System.Text.Json;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services;

public class GetClassesService : IGetClasses
{
    private readonly ICtrlPlayClient _client;
    public GetClassesService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<JsonDocument> GetClassesToday(string accessToken, string today, string statusClass = "IN_PROGRESS",
        string statusCode = "OPEN")
    {
        var response = await _client.GetClasses(accessToken, today);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID);
        
        var responseData = await JsonDocument.ParseAsync(response.Content!);
        return responseData;
    }
}