using Microsoft.EntityFrameworkCore;
using Squeeze.Repository.IRepository;
using Squeeze.Repository;
using Squeeze.Service.IService;
using Squeeze.Service;

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

// Add DbContext configuration if using Entity Framework with MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));
// Pass på å justere versjonen til den faktiske MySQL server versjonen du bruker

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme;


// Dependency Injection for services and repositories
builder.Services.AddScoped<IBestillingService, BestillingService>();
builder.Services.AddScoped<IBestillingRepository, BestillingRepository>();
builder.Services.AddScoped<IKundeService, KundeService>();
builder.Services.AddScoped<IKundeRepository, KundeRepository>();
builder.Services.AddScoped<ILemonadeService, LemonadeService>();
builder.Services.AddScoped<ILemonadeRepository, LemonadeRepository>();

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

app.UseMiddleware<BasicAuthMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
