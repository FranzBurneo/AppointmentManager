using System.Text;
using dotenv.net;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using AppointmentManager.Application.Interfaces;
using AppointmentManager.Application.Services;
using AppointmentManager.Application.Validators.Company;
using AppointmentManager.Domain.Interfaces;
using AppointmentManager.Infrastructure.Data;
using AppointmentManager.Infrastructure.Repositories;
using AppointmentManager.Application.Validators.Employee;
using AppointmentManager.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// 1. Cargar variables de entorno (.env)
DotEnv.Load();

// 2. Configuración de servicios ---------------------------------------------------
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 2.1 Controllers y FluentValidation
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateEmployeeValidator>();

// 2.2 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2.3 DbContext (cadena desde .env o appsettings)
var connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2.4 Repositories y Services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IEmployeeScheduleService, EmployeeScheduleService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

// 2.5 JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// 3. Construir la app -------------------------------------------------------------
var app = builder.Build();

// 4. Middlewares ------------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi(); // si estás usando NSwag
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 5. Inicialización de base de datos ---------------------------------------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var connectionCheck = context.Database.GetConnectionString();

        if (!string.IsNullOrWhiteSpace(connectionCheck))
        {
            await DbInitializer.SeedAsync(context);
        }
        else
        {
            Console.WriteLine("No se encontró la cadena de conexión. SeedAsync omitido.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inicializando la base de datos: {ex.Message}");
    }
}

// 6. Correr la app ----------------------------------------------------------------
app.Run();