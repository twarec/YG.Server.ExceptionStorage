using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using YG.Server.ExceptionStorage.Controllers.Models;
using YG.Server.ExceptionStorage.DataBase.Models;
using YG.Server.ExceptionStorage.Services;

namespace YG.Server.ExceptionStorage.Controllers;

[ApiController]
[Route("ExceptionStorage/[controller]")]
[ApiExplorerSettings(GroupName = "ExceptionStorage")]
public class BodyController(IBodyService bodyService) : ControllerBase
{
    [HttpPost("Root/{rootId}")]
    [ProducesResponseType(typeof(Body), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody, Required] BodyCreateData data, [FromRoute, Required, MinLength(1)] string rootId)
    {
        var result = await bodyService.CreateAsync(data.ToDataBase(), rootId);
        if(result == null) return NotFound();
        return Ok(result);
    }


}
