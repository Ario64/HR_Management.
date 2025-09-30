using HR_Management.Domain.Common;
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

    #region Save change async configuration

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.LastModifiedDate = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreateDate = DateTime.UtcNow;
            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    #endregion

    #region Save change configuration

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.LastModifiedDate = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreateDate = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    #endregion

}
