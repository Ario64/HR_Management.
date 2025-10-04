using HR_Management.Application.Features.LeaveType.Request.Queries;
using HR_Management.Domain.DTOs.LeaveTypeDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HR_Management.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // GET: api/<LeaveTypeController>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LeaveTypeDto>>> Get()
    {
        var lravrTypeList = await _mediator.Send(new GetLeaveTypeListRequest());
        return Ok(lravrTypeList);
    }

    // GET api/<LeaveTypeController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<LeaveTypeController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<LeaveTypeController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<LeaveTypeController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
