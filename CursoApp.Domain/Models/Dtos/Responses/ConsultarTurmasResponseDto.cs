using CursoApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Dtos.Responses
{
    public class ConsultarTurmasResponseDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Numero { get; set; }
        public string? AnoLetivo { get; set; }
        public Nivel? Nivel { get; set; }
    }
}
