using HR_Management.Application.Infrastructure.Services.EmailService;
using HR_Management.Application.Models;
using HR_Management.Application.UintOfWork;
using HR_Management.Domain.Repositories;
using HR_Management.Infrastructure.Context;
using HR_Management.Infrastructure.Repositories;
using HR_Management.Infrastructure.Services.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddTransient<IEmailSender, EmailSender>();


        return services;
    }
}
