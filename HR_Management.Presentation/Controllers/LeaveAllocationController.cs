using HR_Management.Application.DTOs.Resources;
using HR_Management.Application.Features.LeaveAllocation.Request.Commands;
using HR_Management.Application.Features.LeaveAllocation.Request.Queries;
using HR_Management.Domain.DTOs.LeaveAllocationDTOs;
using HR_Management.Presentation.Hatoeas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly IHttpContextAccessor _contextAccessor;

    public LeaveAllocationController(IMediator mediator, IHttpContextAccessor contextAccessor)
    {
        _mediator = mediator;
        _contextAccessor = contextAccessor;
    }

    // GET: api/<LeaveAllocationController>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LeaveAllocationDto>>> Get()
    {
        var leaveAllocationList = await _mediator.Send(new GetLeaveAllocationListRequest());
        var linkBuilder = new LinkBuilder<LeaveAllocationController>(Url, _contextAccessor);

        var resources = leaveAllocationList.Select(la => new LeaveAllocationResource
        {
            Id = la.Id,
            LeaveTypeId = la.LeaveTypeId,
            NumberOfDate = la.NumberOfDate,
            Period = la.Period,
            Links = linkBuilder.BuildLinkForList(la.Id).ToList()
        });

        return Ok(resources);
    }

    // GET api/<LeaveAllocationController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationRequest(id));
        var linkBuilder = new LinkBuilder<LeaveAllocationController>(Url, _contextAccessor);

        var resource = new LeaveAllocationResource
        {
            Id = leaveAllocation.Id,
            LeaveTypeId = leaveAllocation.LeaveTypeId,
            NumberOfDate = leaveAllocation.NumberOfDate,
            Period = leaveAllocation.Period,
            Links = linkBuilder.BuildLinkForItem(leaveAllocation.Id).ToList()
        };

        return Ok(resource);
    }

    // POST api/<LeaveAllocationController>
    [HttpPost]
    public async Task<ActionResult<LeaveAllocationDto>> Post([FromBody] CreateLeaveAllocationDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdLeaveAllocation = await _mediator.Send(new CreateLeaveAllocationCommandRequest(model));
        var linkBuilder = new LinkBuilder<LeaveAllocationController>(Url, _contextAccessor);

        var resources = new LeaveAllocationResource
        {
            Id = createdLeaveAllocation.Id,
            LeaveTypeId = model.LeaveTypeId,
            NumberOfDate = model.NumberOfDate,
            Period = model.Period,
            Links = linkBuilder.BuildLinkAfterCreate(createdLeaveAllocation.Id).ToList()
        };

        return CreatedAtAction("Get", new { createdLeaveAllocation.Id }, createdLeaveAllocation);
    }

    // PUT api/<LeaveAllocationController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] EditLeaveAllocationDto model)
    {
        if (id == 0 || id != model.Id)
            return BadRequest("Invalid Id !");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _mediator.Send(new EditLeaveAllocationCommandRequest(id, model));
        var linkBuilder = new LinkBuilder<LeaveAllocationController>(Url, _contextAccessor);
        var resourse = new LeaveAllocationResource
        {
            Id = model.Id,
            LeaveTypeId = model.LeaveTypeId,
            NumberOfDate = model.NumberOfDate,
            Period = model.Period,
            Links = linkBuilder.BuildLinkAfterUpdate(id).ToList()
        };
        return Ok(resourse);

    }

    // DELETE api/<LeaveAllocationController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (id == 0)
            return BadRequest("Invalid Id !");

        await _mediator.Send(new DeleteLeaveAllocationCommandRequest(id));
        var linkBuilder = new LinkBuilder<LeaveAllocationController>(Url, _contextAccessor);
        var resourse = linkBuilder.BuildLinkAfterDelete().ToList();
        return Ok(resourse);
    }
}
