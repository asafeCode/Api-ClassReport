using System.Text.Json;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetBookIdAndDate
{
    public Task<JsonDocument> GetBookIdAndDate (string accessToken, string classId,  string dateRangeBefore, 
         string dateRangeAfter);
}