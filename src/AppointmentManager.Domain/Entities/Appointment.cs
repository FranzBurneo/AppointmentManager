using System.ComponentModel.DataAnnotations;

namespace AppointmentManager.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ServiceId { get; set; }
        public Service? Service { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        public string ClientPhone { get; set; } = string.Empty;

        public string? ClientEmail { get; set; }
    }
}