using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Dtos.Requests
{
    public class CriarMatriculaRequestDto
    {
        [Required(ErrorMessage = "Informe o ID da turma. ")]
        public Guid? TurmaId { get; set; }

        [Required(ErrorMessage = "Informe o ID do aluno. ")]
        public Guid? AlunoId { get; set; }
    }
}
