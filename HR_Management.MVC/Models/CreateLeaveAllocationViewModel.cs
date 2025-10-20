namespace HR_Management.MVC.Models;

public record CreateLeaveAllocationViewModel
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string EmployeeName { get; set; } = string.Empty;
    public int Period { get; set; }
}
