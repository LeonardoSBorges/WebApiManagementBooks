using FluentValidation;
using WebBookManagement.Domain.Commands.Requests;

namespace WebBookManagement.Domain.Validators
{
    public class DeleteBookRequestValidation : AbstractValidator<DeleteBookRequest>
    {
        public DeleteBookRequestValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("O id deve ser existente na memoria, por favor insira um valor que seja existente.");
        } 
    }
}
