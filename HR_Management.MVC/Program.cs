using HR_Management.MVC.Contracts;
using HR_Management.MVC.Profiles;
using HR_Management.MVC.Services;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure the API client with the base address from appsettings.json
            var apiAddress = builder.Configuration.GetValue<string>("ApiAddress");
            if (string.IsNullOrWhiteSpace(apiAddress))
                throw new InvalidOperationException("ApiAddress is not configured in appsettings.json.");

            builder.Services.AddHttpClient<IClient, Client>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(apiAddress);
                })
                .AddTypedClient<IClient>((httpClient, serviceProvider) =>
                {
                    return new Client(apiAddress, httpClient);
                });

            builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
            builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
