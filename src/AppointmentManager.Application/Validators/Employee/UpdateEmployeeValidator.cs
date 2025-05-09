using AppointmentManager.Application.DTOs.Employee;
using FluentValidation;

namespace AppointmentManager.Application.Validators.Employee
{
    public class UpdateEmployeeValidator : EmployeeValidatorBase<UpdateEmployeeDto>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El Id es obligatorio.");

            ApplyCommonRules();

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("El CompanyId es obligatorio.");
        }
    }
}