namespace AppointmentManager.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<EmployeeSchedule> Schedules { get; set; } = [];
    }
}
