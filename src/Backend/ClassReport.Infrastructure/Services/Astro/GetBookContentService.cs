using System.Text.Json;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetBookContentService :  IGetBookContent
{
    private readonly ICtrlPlayClient _client;
    public GetBookContentService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<JsonDocument> GetBookContent(string accessToken, string bookId)
    {
        var response = await _client.GetBookContent(accessToken, bookId);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID);
        
        var responseData = await JsonDocument.ParseAsync(response.Content!);
        return responseData;
    }
}