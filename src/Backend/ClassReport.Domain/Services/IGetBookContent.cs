using System.Text.Json;

namespace MyRecipeBook.Domain.Services;

public interface IGetBookContent
{
    public Task<JsonDocument> GetBookContent(string accessToken, string bookId);
}