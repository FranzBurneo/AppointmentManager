using System.ComponentModel.DataAnnotations;

namespace AppointmentManager.Domain.Entities
{
    public class EmployeeSchedule
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        [Required]
        public int DayOfWeek { get; set; } // 0 = Domingo, 6 = Sábado

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
    }
}