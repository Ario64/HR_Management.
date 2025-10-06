using HR_Management.Application.Features.LeaveType.Request.Commands;
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
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeRequest(id));
        return Ok(leaveType);
    }

    // POST api/<LeaveTypeController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var leaveType = await _mediator.Send(new CreateLeaveTypeCommandRequest(model));
        return CreatedAtAction(nameof(Get), new { id = leaveType.Id }, leaveType);
    }

    // PUT api/<LeaveTypeController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id,[FromBody] EditLeaveTypeDto model)
    {

        if (id != model.Id)
            return BadRequest("Path id and body id do not match");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _mediator.Send(new EditLeaveTypeCommandRequest(model));
        return NoContent();
    }

    // DELETE api/<LeaveTypeController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (id == 0)
            return BadRequest("Invalid ID");

        await _mediator.Send(new DeleteLeaveTypeCommandRequest(id));
        return NoContent();
    }
}
