using AppointmentManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManager.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!context.Companies.Any())
        {
            context.Companies.AddRange(
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "EasyTech Solutions",
                    Address = "123 Tech Avenue",
                    Phone = "0991234567",
                    Email = "contact@easytech.com",
                    Website = "https://easytech.com",
                    IsActive = true
                },
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "HealthCare Experts",
                    Address = "456 Wellness Blvd",
                    Phone = "0987654321",
                    Email = "info@healthcarex.com",
                    Website = "https://healthcarex.com",
                    IsActive = true
                },
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "AutoDrive Services",
                    Address = "789 Mobility Street",
                    Phone = "0971122334",
                    Email = "support@autodrive.com",
                    Website = "https://autodrive.com",
                    IsActive = true
                }
            );

            await context.SaveChangesAsync();
        }
    }
}