using FluentValidation;

namespace WebApi.Models.AddCustomer
{
    public class AddCustomerInputValidator : AbstractValidator<AddCostumerInput>
    {
        public AddCustomerInputValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Document).IsValidCPF().WithMessage("'Document' é um CPF inválido.");
        }
    }
}
