using AppointmentManager.Application.DTOs.Company;
using FluentValidation;

namespace AppointmentManager.Application.Validators.Company
{
    public class UpdateCompanyValidator : CompanyValidatorBase<UpdateCompanyDto>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El Id de la compañía es obligatorio.");

            ApplyCommonRules();
        }
    }
}