using System.Text.Json;

namespace MyRecipeBook.Domain.Services;

public interface IGetTeacherInfo
{
    public Task<JsonDocument> GetTeacherInfo(string accessToken);
}