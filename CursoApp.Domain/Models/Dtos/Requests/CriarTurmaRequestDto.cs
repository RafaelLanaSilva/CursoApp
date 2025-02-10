using CursoApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Dtos.Requests
{
    public class CriarTurmaRequestDto
    {

        [Required(ErrorMessage = "Por favor, informe o número da turma.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o número da turma.")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o ano letivo da turma.")]
        public string? AnoLetivo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nível da turma.")]
        public Nivel? Nivel { get; set; }
    }
}
