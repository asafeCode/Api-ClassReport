using System.Text.Json;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UseCases.CtrlPlay.GenerateReport;

public interface IGenerateReportUseCase
{
    public Task<string> Execute(RequestClassId request);
}