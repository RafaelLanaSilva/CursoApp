using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Dtos.Responses
{
    public class AlterarAlunoResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public Guid TurmaId { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
