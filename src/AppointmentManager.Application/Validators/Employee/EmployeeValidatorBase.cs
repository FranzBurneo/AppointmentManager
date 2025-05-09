using FluentValidation;

namespace AppointmentManager.Application.Validators.Employee
{
    public abstract class EmployeeValidatorBase<T> : AbstractValidator<T>
    {
        protected void ApplyCommonRules()
        {
            RuleFor(x => x!.GetType().GetProperty("FullName")!.GetValue(x) as string)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre completo no puede tener más de 100 caracteres.");

            RuleFor(x => x!.GetType().GetProperty("Email")!.GetValue(x) as string)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El correo electrónico no es válido.")
                .MaximumLength(255).WithMessage("El correo electrónico no puede tener más de 255 caracteres.");

            RuleFor(x => x!.GetType().GetProperty("Phone")!.GetValue(x) as string)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(20).WithMessage("El teléfono no puede tener más de 20 caracteres.");
        }
    }
}