using HR_Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Infrastructure.Configurationsک
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.LeaveTypeTitle).HasMaxLength(200);
            builder.Property(p => p.DefaultDays);
            builder.Property(p => p.CreateDate);
            builder.Property(p => p.CreatedBy);
            builder.Property(p => p.LastModifiedDate);
            builder.Property(p => p.LastModifiedBy);
        }
    }
}
