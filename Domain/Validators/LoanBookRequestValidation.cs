using FluentValidation;
using WebBookManagement.Domain.Commands.Requests;

namespace WebBookManagement.Domain.Validators
{
    public class LoanBookRequestValidation : AbstractValidator<LoanBookRequest>
    {
        public LoanBookRequestValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Insira um id que seja existente no cache.");
            
        }

        
    }
}
