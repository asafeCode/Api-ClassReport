using System.Text.Json;

namespace MyRecipeBook.Application.UseCases.AstroPortal.TodayClasses;

public interface IGetTodayClassesUseCase
{
    public Task<ClassesResponseDto> Execute();
    
}