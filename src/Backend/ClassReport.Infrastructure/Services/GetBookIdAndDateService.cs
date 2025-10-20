using System.Text.Json;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services;

public class GetBookIdAndDateService : IGetBookIdAndDate
{
    private readonly ICtrlPlayClient _client;
    public GetBookIdAndDateService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public Task<JsonDocument> GetBookIdAndDate(string accessToken, string classId, string dateRangeBefore, string dateRangeAfter)
    {
        throw new NotImplementedException();
    }
}