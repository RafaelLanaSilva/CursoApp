using CursoApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Validations
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(a => a.Id).NotEmpty();

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Informe o nome do aluno")
                .Length(1, 100).WithMessage("Informe o nome do aluno com nomínimo 1 e no máximo 100 caracteres");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Informe o email do aluno")
                .EmailAddress().WithMessage("Informe um endereço de email válido");

            RuleFor(a => a.Cpf)
                .NotEmpty().WithMessage("Informe o CPF do aluno")
                .Matches(@"^\d{11}$").WithMessage("O cpf do cliente deve ter exatamente 11 dígitos.");

        }
    }
}
