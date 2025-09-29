using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Infrastructure.Context;

public class HRDbContext : DbContext
{
    public HRDbContext(DbContextOptions<HRDbContext> options) : base(options) { }

    #region Db Sets

    public DbSet<LeaveType> LeaveTypes { get; set; } = null!;
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; } = null!;
    public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;

    #endregion

    #region Model configuration

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRDbContext).Assembly);

    }

    #endregion

}
