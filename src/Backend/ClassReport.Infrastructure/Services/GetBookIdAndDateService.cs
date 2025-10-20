using System.Text.Json;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services;

public class GetBookIdAndDateService : IGetBookIdAndDate
{
    private readonly ICtrlPlayClient _client;
    public GetBookIdAndDateService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<JsonDocument> GetBookIdAndDate(string accessToken, string classId, string dateRangeBefore, string dateRangeAfter)
    {
        var response = await _client.GetBookIdAndDate(accessToken, classId, dateRangeBefore, dateRangeAfter);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID);
        
        var responseData = await JsonDocument.ParseAsync(response.Content!);
        return responseData;
    }
}