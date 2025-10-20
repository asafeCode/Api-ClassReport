using System.Text.Json;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.TeacherInfo;

public interface IGetTeacherInfoUseCase
{
    public Task<JsonDocument> Execute();
}