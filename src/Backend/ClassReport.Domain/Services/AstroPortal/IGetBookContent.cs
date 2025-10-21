using System.Text.Json;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetBookContent
{
    public Task<JsonDocument> GetBookContent(string accessToken, string bookId);
}