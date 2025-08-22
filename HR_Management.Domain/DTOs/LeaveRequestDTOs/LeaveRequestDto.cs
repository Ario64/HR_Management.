namespace HR_Management.Domain.DTOs.LeaveRequestDTOs;

public record LeaveRequestDto
{
    public int LeaveRequestId { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DateRequest { get; set; }
    public string? RequestComment { get; set; }
    public DateTime ActionDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}