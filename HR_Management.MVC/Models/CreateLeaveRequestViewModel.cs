namespace HR_Management.MVC.Models
{
    public class CreateLeaveRequestViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequest { get; set; }
        public string? RequestComment { get; set; }
        public DateTime ActionDate { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
