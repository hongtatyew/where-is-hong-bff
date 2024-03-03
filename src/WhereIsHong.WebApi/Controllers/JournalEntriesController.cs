using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhereIsHong.Services.Queries;

namespace WhereIsHong.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JournalEntriesController(IMediator _mediator) : ControllerBase
{
    /// <summary>
    /// Perform x + y
    /// </summary>
    /// <param name="x">Left hand operand of the arithmetic operation.</param>
    /// <param name="y">Right hand operand of the arithmetic operation.</param>
    /// <returns>Sum of x and y.</returns>
    [HttpGet]
    public async Task<IActionResult> GetJournalEntries()
    {
        var response = await _mediator.Send(new GetJournalEntriesQuery(), default);
        return Ok(response);
    }
}
