using HR_Management.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Management.Infrastructure.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser
            {
                Id = "7b9a4d2c-3e8d-4c5a-9f5f-37a6e0f7c1a2",
                Email = "shahrokhi20@yahoo.com",
                UserName = "ario9",
                LastName = "Shahrokhi",
                FirstName = "Ghasem",
                PasswordHash = passwordHasher.HashPassword(null, "Gh1038339sh@"),
                EmailConfirmed = true
            }
            , new ApplicationUser
             {
                 Id = "c4e81b39-6f21-4b5d-9c48-9f08e73fbb65",
                 Email = "shahrokhi20@yahoo.com",
                 UserName = "ario90",
                 LastName = "Shahrokhi",
                 FirstName = "Mozhgan",
                 PasswordHash = passwordHasher.HashPassword(null, "Gh1038339sh@"),
                 EmailConfirmed = true
             });
    }
}
