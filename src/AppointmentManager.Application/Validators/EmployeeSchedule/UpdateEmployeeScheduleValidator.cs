using AppointmentManager.Application.DTOs.EmployeeSchedule;
using FluentValidation;

namespace AppointmentManager.Application.Validators.EmployeeSchedule
{
    public class UpdateEmployeeScheduleValidator : AbstractValidator<UpdateEmployeeScheduleDto>
    {
        public UpdateEmployeeScheduleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El ID es obligatorio.");

            Include(new CreateEmployeeScheduleValidator());
        }
    }
}