using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Infrastructure.Configurations.Identity;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasKey(k => new { k.UserId, k.RoleId });

        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "a6b0b5b3-2e13-4b38-a6d1-8a03f6f8c27a",
                UserId = "7b9a4d2c-3e8d-4c5a-9f5f-37a6e0f7c1a2"
            }
            , new IdentityUserRole<string>
            {
                RoleId = "c4e81b39-6f21-4b5d-9c48-9f08e73fbb65",
                UserId = "b2f35f8e-15d2-43c1-90b9-d2b04a34e2aa"
            });
    }
}
