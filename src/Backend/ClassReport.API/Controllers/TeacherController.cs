using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.CtrlPlay.TeacherInfo;

namespace MyRecipeBook.API.Controllers;

public class TeacherController : ClassReportControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IGetTeacherInfoUseCase useCase)
    {
        var response = await  useCase.Execute();
        return Ok(response);
    }
}