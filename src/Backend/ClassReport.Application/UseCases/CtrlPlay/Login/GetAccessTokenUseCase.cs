using Mapster;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.Login;

public class GetAccessTokenUseCase : IGetAcessTokenUseCase
{
    private readonly IGetAccessToken _tokenService;

    public GetAccessTokenUseCase(IGetAccessToken tokenService)
    {
        _tokenService = tokenService;
    }
    
    public async Task<ResponseLoginJson> Execute(RequestLoginJson request)
    {
        Validate(request);
        var requestDto = request.Adapt<RequestLoginDto>();
        var accessToken = await _tokenService.GetAccessToken(requestDto);
        return new ResponseLoginJson
        {
            AccessToken = accessToken
        };
    }

    private void Validate(RequestLoginJson request)
    {
        var validator = new GetAccessTokenValidator();
        var result = validator.Validate(request);
        if (result.IsValid.IsFalse())
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}