using HR_Management.Domain.Common;

namespace HR_Management.Domain.Entities;

public class User : BaseEntity
{
   public string? Email { get; set; }
   public string? FirstName { get; set; }
   public string? LastName { get; set; }
}
