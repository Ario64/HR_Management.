using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Infrastructure.Configurations
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Period);
            builder.Property(p => p.NumberOfDate);
            builder.Property(p => p.LastModifiedBy);
            builder.Property(p => p.LastModifiedDate);
            builder.Property(p => p.CreateDate);
            builder.Property(p => p.CreatedBy);
            builder.HasOne(h => h.LeaveType).WithMany(w => w.LeaveAllocations).HasForeignKey(f => f.LeaveTypeId);
        }
    }
}
