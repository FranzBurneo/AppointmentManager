namespace AppointmentManager.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public bool IsActive { get; set; } = true;

    // Relaciones futuras: Servicios, Usuarios, Citas
    //public ICollection<Service> Services { get; set; } = new List<Service>();
}