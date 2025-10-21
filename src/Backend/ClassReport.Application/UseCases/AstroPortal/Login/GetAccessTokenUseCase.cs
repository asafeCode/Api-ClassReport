using Mapster;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.AstroPortal.Login;

public class GetAccessTokenUseCase : IGetAcessTokenUseCase
{
    private readonly IGetAccessToken _loginService;

    public GetAccessTokenUseCase(IGetAccessToken tokenService)
    {
        _loginService = tokenService;
    }
    
    public async Task<ResponseLoginJson> Execute(RequestLoginJson request)
    {
        Validate(request);
        var requestDto = request.Adapt<RequestLoginDto>();
        var accessToken = await _loginService.GetAccessToken(requestDto);
        
        return new ResponseLoginJson
        {
            AccessToken = accessToken
        };
    }

    private static void Validate(RequestLoginJson request)
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