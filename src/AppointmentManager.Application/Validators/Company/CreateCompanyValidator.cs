using AppointmentManager.Application.DTOs.Company;

namespace AppointmentManager.Application.Validators.Company
{
    public class CreateCompanyValidator : CompanyValidatorBase<CreateCompanyDto>
    {
        public CreateCompanyValidator()
        {
            ApplyCommonRules();
        }
    }
}