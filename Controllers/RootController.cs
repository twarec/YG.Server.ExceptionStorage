using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using YG.Server.ExceptionStorage.Controllers.Models;
using YG.Server.ExceptionStorage.DataBase.Models;
using YG.Server.ExceptionStorage.Services;

namespace YG.Server.ExceptionStorage.Controllers;


[ApiController]
[Route("ExceptionStorage/[controller]")]
[ApiExplorerSettings(GroupName = "ExceptionStorage")]
public class RootController(IRootService rootService) : ControllerBase
{
    [HttpGet("Id/{id}")]
    [ProducesResponseType(typeof(Root), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetFromIdAsync([FromRoute, Required] string id)
    {
        var result = await rootService.GetAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("Range/All")]
    [ProducesResponseType(typeof(IEnumerable<Root>), 200)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await rootService.GetAllAsync());
    }

    [HttpGet("Range")]
    [ProducesResponseType(typeof(IEnumerable<Root>), 200)]
    public async Task<IActionResult> GetRangeAsync([FromQuery, Required] int offset, [FromQuery, Required] int count)
    {
        return Ok(await rootService.GetRangeAsync(offset, count));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Root), 200)]
    public async Task<IActionResult> AddAsync([FromBody, Required] RootCreateData data)
    {
        var result = await rootService.CreateAsync(data.ToDataBase());
        return Ok(result);
    }
}
