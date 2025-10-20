using System.Globalization;
using Mapster;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.Login;

public class GetAccessTokenUseCase : IGetAcessTokenUseCase
{
    private readonly IGetAccessToken _tokenService;
    private readonly IGetClasses _getClasses;
    private readonly IGetTeacherInfo _getTeacherInfo;
    public GetAccessTokenUseCase(IGetAccessToken tokenService,
        IGetClasses getClasses,
        IGetTeacherInfo getTeacherInfo)
    {
        _tokenService = tokenService;
        _getClasses = getClasses;
        _getTeacherInfo = getTeacherInfo;
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