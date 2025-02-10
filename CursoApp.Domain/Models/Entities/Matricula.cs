using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Entities
{
    public class Matricula
    {
        public Guid TurmaId { get; set; }
        public Guid AlunoId { get; set; }

        public Turma? Turma { get; set; }
        public Aluno? Aluno { get; set; }
    }
}
