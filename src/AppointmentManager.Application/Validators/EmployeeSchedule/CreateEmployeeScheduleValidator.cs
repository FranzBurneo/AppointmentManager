using AppointmentManager.Application.DTOs.EmployeeSchedule;
using FluentValidation;

namespace AppointmentManager.Application.Validators.EmployeeSchedule
{
    public class CreateEmployeeScheduleValidator : AbstractValidator<CreateEmployeeScheduleDto>
    {
        public CreateEmployeeScheduleValidator()
        {
            RuleFor(x => x.EmployeeId)
                .NotEmpty().WithMessage("El empleado es obligatorio.");

            RuleFor(x => x.DayOfWeek)
                .InclusiveBetween(0, 6).WithMessage("El día debe estar entre 0 (domingo) y 6 (sábado).");

            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime).WithMessage("La hora de inicio debe ser menor que la de fin.");
        }
    }
}