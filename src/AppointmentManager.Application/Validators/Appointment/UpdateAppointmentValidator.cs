using AppointmentManager.Application.DTOs.Appointment;
using FluentValidation;

namespace AppointmentManager.Application.Validators.Appointment
{
    public class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentDto>
    {
        public UpdateAppointmentValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            Include(new CreateAppointmentValidator());
        }
    }
}