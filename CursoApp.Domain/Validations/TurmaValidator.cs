using CursoApp.Domain.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Validations
{
    public class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(t => t.Id).NotEmpty();

            RuleFor(t => t.Nome)
                .NotEmpty().WithMessage("Informe o nome da Turma");

            RuleFor(t => t.Numero)
                .NotEmpty().WithMessage("Informe o número da Turma");

            RuleFor(t => t.Nivel)
                .NotEmpty().WithMessage("Informe o nível da turma");
        }
    }
}
