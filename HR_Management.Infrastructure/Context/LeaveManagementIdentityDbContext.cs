using HR_Management.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Infrastructure.Context;

public class LeaveManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public LeaveManagementIdentityDbContext(DbContextOptions<LeaveManagementIdentityDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementIdentityDbContext).Assembly);
    }
}
