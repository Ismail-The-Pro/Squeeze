using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Squeeze.Middleware;
using Squeeze.Models;
using Squeeze.Repository;
using Squeeze.Repository.IRepository;
using Squeeze.Service;
using Squeeze.Service.IService;
using Squeeze.Service.Squeeze.Service;
using System;

namespace Squeeze
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Squeeze API",
                    Version = "v1",
                    Description = "En API for håndtering av bestillinger, produkter, og kunder for Squeeze."
                });
            });

            // Add DbContext configuration for Entity Framework with MySQL
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21))));
            // Ensure the version matches your actual MySQL server version

            // Dependency Injection for services and repositories
            builder.Services.AddScoped<IBestillingService, BestillingService>();
            builder.Services.AddScoped<IBestillingRepository, BestillingRepository>();
            builder.Services.AddScoped<IKundeService, KundeService>();
            builder.Services.AddScoped<IKundeRepository, KundeRepository>();
            builder.Services.AddScoped<ILemonadeService, LemonadeService>();
            builder.Services.AddScoped<ILemonadeRepository, LemonadeRepository>();

            // Configure Basic Authentication
            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // Configure the HTTP request pipeline.
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Squeeze API V1");
                    c.RoutePrefix = string.Empty; // Swagger UI at the root (http://localhost:<port>/)
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); // Activate Authentication middleware
            app.UseAuthorization();  // Activate Authorization middleware

            app.MapControllers();

            app.Run();
        }
    }
}
