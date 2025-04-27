using AppointmentManager.Application.Interfaces;
using AppointmentManager.Application.Services;
using AppointmentManager.Domain.Interfaces;
using AppointmentManager.Infrastructure.Data;
using AppointmentManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración 
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Dependencias (Repositories y Services)
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>(); 
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IEmployeeScheduleService, EmployeeScheduleService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Inicializar base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var connectionStringCheck = context.Database.GetConnectionString();

        if (!string.IsNullOrWhiteSpace(connectionStringCheck))
        {
            await DbInitializer.SeedAsync(context);
        }
        else
        {
            Console.WriteLine("No se encontró la cadena de conexión, se omitió SeedAsync.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al inicializar la base de datos: {ex.Message}");
    }
}

app.Run();