using MediatR;
using Microsoft.AspNetCore.Mvc;
using WhereIsHong.Services.Queries;

namespace WhereIsHong.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JournalEntriesController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetJournalEntries()
    {
        var response = await _mediator.Send(new GetJournalEntriesQuery(), default);
        return Ok(response);
    }
}
