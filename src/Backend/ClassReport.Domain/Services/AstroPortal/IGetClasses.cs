using System.Text.Json;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetClasses
{
    public Task<ClassesResponseDto> GetClassesToday(string accessToken,  string today, 
        string statusClass = "IN_PROGRESS", string statusCode = "OPEN");
}