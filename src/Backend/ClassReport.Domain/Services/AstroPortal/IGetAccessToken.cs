using MyRecipeBook.Domain.Dtos.Requests;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetAccessToken
{
    Task<string> GetAccessToken(RequestLoginDto request);
}