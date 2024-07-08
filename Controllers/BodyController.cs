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
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("Root/{rootId}/Range")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRange([FromRoute, Required] string rootId, [FromQuery, Required] int offset, [FromQuery, Required] int count)
    {
        return Ok(await bodyService.GetRangeAsync(offset, count, rootId));
    }

    [HttpGet("Root/{rootId}/Type/{type}/Range")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRange([FromRoute, Required] string rootId, [FromRoute, Required] string type, [FromQuery, Required] int offset, [FromQuery, Required] int count)
    {
        return Ok(await bodyService.GetRangeAsync(offset, count, rootId, type));
    }

    [HttpGet("Root/{rootId}/Type/{type}/Name/{name}/Range")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRange([FromRoute, Required] string rootId, [FromRoute, Required] string type, [FromRoute, Required] string name, [FromQuery, Required] int offset, [FromQuery, Required] int count)
    {
        return Ok(await bodyService.GetRangeAsync(offset, count, rootId, type, name));
    }

    [HttpGet("Root/{rootId}/Range/All")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromRoute, Required] string rootId)
    {
        return Ok(await bodyService.GetAllAsync(rootId));
    }

    [HttpGet("Root/{rootId}/Type/{type}/Range/All")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromRoute, Required] string rootId, [FromRoute, Required] string type)
    {
        return Ok(await bodyService.GetAllAsync(rootId, type));
    }

    [HttpGet("Root/{rootId}/Type/{type}/Name/{name}/Range/All")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromRoute, Required] string rootId, [FromRoute, Required] string type, [FromRoute, Required] string name)
    {
        return Ok(await bodyService.GetAllAsync(rootId, type, name));
    }

    [HttpGet("Range/Filter")]
    [ProducesResponseType(typeof(IEnumerable<Body>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRangeFilterAsync([FromQuery] string? rootId, [FromQuery] string? type, [FromQuery] string? name, [FromQuery] DateTime? after, [FromQuery] DateTime? before, [FromQuery, Required] int offset, [FromQuery, Required] int count)
    {
        return Ok(await bodyService.GetRangeFilterAsync(offset, count, rootId, type, name, after, before));
    }
}
