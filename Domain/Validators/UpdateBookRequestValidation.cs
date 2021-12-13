using FluentValidation;
using WebBookManagement.Domain.Commands.Requests;

namespace WebBookManagement.Domain.Validators
{
    public class UpdateBookRequestValidation : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O titulo nao pode ser nulo.")
                .MinimumLength(2).WithMessage("Deve conter entre 2 a 100 caracteres.")
                .MaximumLength(100).WithMessage("Limite de caracteres foi excedido, insira entre 2 a 100 caracteres.");
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Insira um id que seja existente no cache.");
        }
    }
}
