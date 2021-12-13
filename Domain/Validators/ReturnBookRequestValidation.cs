using FluentValidation;
using WebBookManagement.Domain.Commands.Requests;

namespace WebBookManagement.Domain.Validators
{
    public class ReturnBookRequestValidation : AbstractValidator<ReturnBookRequest>
    {
        public ReturnBookRequestValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Insira um id que seja existente no cache.");
            
        }
    }
}
