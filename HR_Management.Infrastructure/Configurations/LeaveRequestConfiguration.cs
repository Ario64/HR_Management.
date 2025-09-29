using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Infrastructure.Configurations;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.StartDate);
        builder.Property(p => p.RequestComment).HasMaxLength(700);
        builder.Property(p => p.ActionDate);
        builder.Property(p => p.Approved);
        builder.Property(p => p.Cancelled);
        builder.Property(p => p.LastModifiedBy);
        builder.Property(p => p.LastModifiedDate);
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.CreatedBy);
        builder.HasOne(h => h.LeaveType).WithMany(w => w.LeaveRequests).HasForeignKey(w => w.LeaveTypeId);
    }
}
