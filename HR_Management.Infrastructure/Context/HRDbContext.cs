using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Infrastructure.Context;

public class HRDbContext : DbContext
{
    public HRDbContext(DbContextOptions<HRDbContext> options) : base(options) { }

    #region Db Sets

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    #endregion

    #region Model configuration

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Leave Type

        modelBuilder.Entity<LeaveType>(lt =>
        {
            lt.HasKey(k => k.Id);
            lt.Property(p => p.LeaveTypeTitle).HasMaxLength(200);
            lt.Property(p => p.DefaultDays);
            lt.Property(p => p.CreateDate);
            lt.Property(p => p.CreatedBy);
            lt.Property(p => p.LastModifiedDate);
            lt.Property(p => p.LastModifiedBy);
        });

        #endregion

        #region Leave Request

        modelBuilder.Entity<LeaveRequest>(lr =>
        {
            lr.HasKey(k => k.Id);
            lr.Property(p => p.StartDate);
            lr.Property(p => p.RequestComment).HasMaxLength(700);
            lr.Property(p => p.ActionDate);
            lr.Property(p => p.Approved);
            lr.Property(p => p.Cancelled);
            lr.Property(p => p.LastModifiedBy);
            lr.Property(p => p.LastModifiedDate);
            lr.Property(p => p.CreateDate);
            lr.Property(p => p.CreatedBy);
            lr.HasOne(h => h.LeaveType).WithMany(w => w.LeaveRequests).HasForeignKey(w => w.LeaveTypeId);
        });

        #endregion

        #region Leave Allocation

        modelBuilder.Entity<LeaveAllocation>(la =>
        {
            la.HasKey(k => k.Id);
            la.Property(p => p.Period);
            la.Property(p => p.NumberOfDate);
            la.Property(p => p.LastModifiedBy);
            la.Property(p => p.LastModifiedDate);
            la.Property(p => p.CreateDate);
            la.Property(p => p.CreatedBy);
            la.HasOne(h => h.LeaveType).WithMany(w => w.LeaveAllocations).HasForeignKey(f => f.LeaveTypeId);
        });

        #endregion
    }

    #endregion

}
