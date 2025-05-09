using FluentValidation;

namespace AppointmentManager.Application.Validators.Company
{
    public abstract class CompanyValidatorBase<T> : AbstractValidator<T>
    {
        protected void ApplyCommonRules()
        {
            RuleFor(x => x!.GetType().GetProperty("Name")!.GetValue(x) as string)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede tener más de 100 caracteres.");

            RuleFor(x => x!.GetType().GetProperty("Address")!.GetValue(x) as string)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(200).WithMessage("La dirección no puede tener más de 200 caracteres.");

            RuleFor(x => x!.GetType().GetProperty("Phone")!.GetValue(x) as string)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(20).WithMessage("El teléfono no puede tener más de 20 caracteres.");

            RuleFor(x => x!.GetType().GetProperty("Email")!.GetValue(x) as string)
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress().WithMessage("El correo electrónico no es válido.")
                .MaximumLength(255).WithMessage("El correo electrónico no puede tener más de 255 caracteres.");

            RuleFor(x => x!.GetType().GetProperty("Website")!.GetValue(x) as string)
                .MaximumLength(255).WithMessage("El sitio web no puede tener más de 255 caracteres.");
        }
    }
}