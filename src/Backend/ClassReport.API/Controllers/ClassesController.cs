using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.CtrlPlay.TodayClasses;

namespace MyRecipeBook.API.Controllers;

public class ClassesController : ClassReportControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IGetTodayClassesUseCase useCase)
    {
        var response = await  useCase.Execute();
        return Ok(response);
    }
}