using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Infrastructure.Configurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "a6b0b5b3-2e13-4b38-a6d1-8a03f6f8c27a",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "b2f35f8e-15d2-43c1-90b9-d2b04a34e2aa",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            });
    }
}
