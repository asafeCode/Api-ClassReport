using System.Text.Json;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services;

public class GetBookContentService :  IGetBookContent
{
    private readonly ICtrlPlayClient _client;
    public GetBookContentService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public Task<JsonDocument> GetBookContent(string accessToken, string bookId)
    {
        throw new NotImplementedException();
    }
}