using HR_Management.Application.DTOs.Resources;
using HR_Management.Application.Features.LeaveRequest.Handler.Commands;
using HR_Management.Application.Features.LeaveRequest.Handler.Queries;
using HR_Management.Domain.DTOs.LeaveRequestDTOs;
using HR_Management.Presentation.Hatoeas;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace HR_Management.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // GET: api/<LeaveRequestController>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LeaveRequestDto>>> Get()
    {
        var leaveRequestList = await _mediator.Send(new GetLeaveRequestListRequest());
        var linkBuilder = new LinkBuilder(Url);

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
        var linkbuilder = new LinkBuilder(Url);

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

        var createdLeaveRequestId = await _mediator.Send(new CreateLeaveRequestCommandRequest(model));
        var linkbuilder = new LinkBuilder(Url);

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
            Links = linkbuilder.BuildLinkAfterCreate(createdLeaveRequestId).ToList()
        };

        return Ok(resource);
    }

    // PUT api/<LeaveRequestController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<LeaveRequestController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
