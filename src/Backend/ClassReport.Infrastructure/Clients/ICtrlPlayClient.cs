using MyRecipeBook.Domain.Dtos;
using Refit;

namespace MyRecipeBook.Infrastructure.Clients;

public interface ICtrlPlayClient
{
    [Post("/auth/token/")]
    public Task<IApiResponse<Stream>> Login([Body] RequestLoginDto request);
}