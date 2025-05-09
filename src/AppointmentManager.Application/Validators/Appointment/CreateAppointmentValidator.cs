using AppointmentManager.Application.DTOs.Appointment;
using FluentValidation;

namespace AppointmentManager.Application.Validators.Appointment
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentDto>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.ServiceId).NotEmpty();
            RuleFor(x => x.EmployeeId).NotEmpty();
            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.Now).WithMessage("La fecha debe ser en el futuro.");
            RuleFor(x => x.ClientName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ClientPhone).NotEmpty().MaximumLength(20);
            RuleFor(x => x.ClientEmail).EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.ClientEmail));
        }
    }
}