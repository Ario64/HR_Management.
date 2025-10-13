using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models;

public record CreateLeaveTypeViewModel
{
    [Required]
    [Display(Name = "Leave Type Name")]
    public required string Name { get; set; }

    [Required]
    [Display(Name = "Default Days")]
    public required int DefaultDays { get; set; }
}
