using AppointmentManager.Application.DTOs.Employee;
using FluentValidation;

namespace AppointmentManager.Application.Validators.Employee
{
    public class CreateEmployeeValidator : EmployeeValidatorBase<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            ApplyCommonRules();

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("El CompanyId es obligatorio.");
        }
    }
}