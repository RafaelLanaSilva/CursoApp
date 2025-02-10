using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Dtos.Responses
{
    public class ExcluirMatriculaResponseDto
    {
        public Guid? TurmaId { get; set; }
        public Guid? AlunoId { get; set; }
    }
}
