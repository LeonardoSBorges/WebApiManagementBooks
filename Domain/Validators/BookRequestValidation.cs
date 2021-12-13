using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBookManagement.Domain.Commands.Requests;
using FluentValidation;

namespace WebBookManagement.Domain.Validators
{
    public class BookRequestValidation : AbstractValidator<BookRequest>
    {
        public BookRequestValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O titulo nao pode ser nulo.")
                .MinimumLength(2).WithMessage("Deve conter entre 2 a 100 caracteres.")
                .MaximumLength(100).WithMessage("Limite de caracteres foi excedido, insira entre 2 a 100 caracteres.");
        }

    }
}
