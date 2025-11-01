using HR_Management.Application;
using HR_Management.Infrastructure;
using Microsoft.OpenApi.Models;

namespace HR_Management.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                               Enter 'Bearer' [space] and then your token in the text input below.
                               Example: 'Bearer 1234sddsw.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                   new OpenApiSecurityScheme
                   {
                      Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                      },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header
                   },
                    new List<string>()
                }
            });
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "HR Management Api"
            });
        });

        //IoC
        builder.Services.ConfigureApplicationServices();
        builder.Services.ConfigureInfrastructureServices(builder.Configuration);
        builder.Services.AddHttpContextAccessor();

        //Add corse
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("AllowAll");

        app.MapControllers();

        app.Run();
    }
}
