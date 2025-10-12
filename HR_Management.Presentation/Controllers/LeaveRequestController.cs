using HR_Management.Application.DTOs.Resources;
using HR_Management.Application.Features.LeaveAllocation.Request.Commands;
using HR_Management.Application.Features.LeaveRequest.Handler.Commands;
using HR_Management.Application.Features.LeaveRequest.Handler.Queries;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using HR_Management.Presentation.Hatoeas;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace HR_Management.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LeaveRequestController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    // GET: api/<LeaveRequestController>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LeaveRequestDto>>> Get()
    {
        var leaveRequestList = await _mediator.Send(new GetLeaveRequestListRequest());
        var linkBuilder = new LinkBuilder<LeaveRequestController>(Url, _httpContextAccessor);
        var resources = leaveRequestList.Select(leaveRequest => new LeaveRequestResource
        {
            Id = leaveRequest.Id,
            ActionDate = leaveRequest.ActionDate,
            Approved = leaveRequest.Approved,
            Cancelled = leaveRequest.Cancelled,
            DateRequest = leaveRequest.DateRequest,
            EndDate = leaveRequest.EndDate,
            LeaveTypeId = leaveRequest.LeaveTypeId,
            RequestComment = leaveRequest.RequestComment,
            StartDate = leaveRequest.StartDate,
            Links = linkBuilder.BuildLinkForList(leaveRequest.Id).ToList()
        });

        return Ok(resources);
    }

    // GET api/<LeaveRequestController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestRequest(id));
        var linkbuilder = new LinkBuilder<LeaveRequestController>(Url, _httpContextAccessor);
        var resource = new LeaveRequestResource
        {
            Id = leaveRequest.Id,
            ActionDate = leaveRequest.ActionDate,
            Approved = leaveRequest.Approved,
            Cancelled = leaveRequest.Cancelled,
            DateRequest = leaveRequest.DateRequest,
            EndDate = leaveRequest.EndDate,
            LeaveTypeId = leaveRequest.LeaveTypeId,
            RequestComment = leaveRequest.RequestComment,
            StartDate = leaveRequest.StartDate,
            Links = linkbuilder.BuildLinkForItem(leaveRequest.Id).ToList()
        };

        return Ok(resource);
    }

    // POST api/<LeaveRequestController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdLeaveRequest = await _mediator.Send(new CreateLeaveRequestCommandRequest(model));
        var linkbuilder = new LinkBuilder<LeaveRequestController>(Url, _httpContextAccessor);
        var resource = new LeaveRequestResource
        {
            ActionDate = model.ActionDate,
            Approved = model.Approved,
            Cancelled = model.Cancelled,
            DateRequest = model.DateRequest,
            EndDate = model.EndDate,
            LeaveTypeId = model.LeaveTypeId,
            RequestComment = model.RequestComment,
            StartDate = model.StartDate,
            Links = linkbuilder.BuildLinkAfterCreate(createdLeaveRequest.Id).ToList()
        };

        return CreatedAtAction("Get", new { id = createdLeaveRequest.Id }, createdLeaveRequest);
    }

    // PUT api/<LeaveRequestController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] EditLeaveRequestDto model)
    {
        if (id == 0 || id != model.Id)
            return NotFound();

        await _mediator.Send(new GetLeaveRequestRequest(id));
        var linkbuilder = new LinkBuilder<LeaveRequestController>(Url, _httpContextAccessor);
        var resource = new LeaveRequestResource()
        {
            ActionDate = model.ActionDate,
            DateRequest = model.DateRequest,
            EndDate = model.EndDate,
            LeaveTypeId = model.LeaveTypeId,
            RequestComment = model.RequestComment,
            StartDate = model.StartDate,
            Links = linkbuilder.BuildLinkAfterUpdate(id)
        };
        return Ok(resource);
    }

    // DELETE api/<LeaveRequestController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (id == 0)
            return BadRequest("Invalid Id!");

        await _mediator.Send(new DeleteLeaveAllocationCommandRequest(id));
        var linkBuilder = new LinkBuilder<LeaveAllocationController>(Url, _httpContextAccessor);
        var resource = linkBuilder.BuildLinkAfterDelete();
        return Ok(resource);
    }

}
