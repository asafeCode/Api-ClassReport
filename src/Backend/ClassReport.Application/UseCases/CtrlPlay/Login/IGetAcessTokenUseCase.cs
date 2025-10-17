using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.Login;

public interface IGetAcessTokenUseCase
{
    public Task<ResponseLoginJson> Execute(RequestLoginJson request);
}