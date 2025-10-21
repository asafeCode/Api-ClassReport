using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;

namespace MyRecipeBook.Application.UseCases.AstroPortal.TeacherInfo;

public interface IGetTeacherInfoUseCase
{
    public Task<TeacherResponseDto> Execute();
}