using System.Text.Json;

namespace MyRecipeBook.Domain.Services;

public interface IGetClasses
{
    public Task<JsonDocument> GetClassesToday(string accessToken,  string today, 
        string statusClass = "IN_PROGRESS", string statusCode = "OPEN");
}