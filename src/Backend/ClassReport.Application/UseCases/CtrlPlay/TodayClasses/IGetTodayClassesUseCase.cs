using System.Text.Json;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.TodayClasses;

public interface IGetTodayClassesUseCase
{
    public Task<JsonDocument> Execute();
    
}