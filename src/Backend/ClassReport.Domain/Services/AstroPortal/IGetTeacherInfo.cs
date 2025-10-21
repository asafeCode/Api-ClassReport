using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetTeacherInfo
{
    public Task<TeacherResponseDto> GetTeacherInfo(string accessToken);
}