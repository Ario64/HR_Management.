using HR_Management.Application.Hatoeas;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;
using HR_Management.Infrastructure.Repositories;
using HR_Management.Infrastructure.Services.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HR_Management.Application.Contracts.EmailService;
using HR_Management.Application.Models.Identity;
using HR_Management.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Infrastructure.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HR_Management.Infrastructure;

public static class InfrastructureServicesRegisteration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HRDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HRConnectionString"));
        });

        services.AddScoped<IUnitOfWork, HR_Management.Infrastructure.UnitOfWork.UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

        services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HRConnectionString"),
            b => b.MigrationsAssembly(typeof(LeaveManagementIdentityDbContext).Assembly.FullName));
        });

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>()
                .AddDefaultTokenProviders();

        services.AddTransient<IAuthenticationService, AuthenticationService>();
        //services.AddTransient<IUser, AuthenticationService>();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = true,
                 ValidateIssuerSigningKey = true,
                 ValidateAudience = true,
                 ValidateLifetime = true,
                 ClockSkew = TimeSpan.Zero,
                 ValidIssuer = configuration["JwtSettings:Issuer"],
                 ValidAudience = configuration["JwtSettings:Audience"],
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
             };
         });
        services.AddTransient<IEmailSender, EmailSender>();


        return services;
    }
}
