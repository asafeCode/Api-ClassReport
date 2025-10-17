using MyRecipeBook.Domain.Dtos;

namespace MyRecipeBook.Domain.Services;

public interface IGetAccessToken
{
    Task<string> GetAccessToken(RequestLoginDto request);
}