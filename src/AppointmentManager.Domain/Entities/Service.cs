using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentManager.Domain.Entities
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public Company? Company { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}