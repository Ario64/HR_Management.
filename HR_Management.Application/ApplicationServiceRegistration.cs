using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Management.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        //service.AddAutoMapper(typeof(MappingProfile));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}