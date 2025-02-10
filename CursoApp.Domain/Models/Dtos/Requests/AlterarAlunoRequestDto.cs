using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Dtos.Requests
{
    public class AlterarAlunoRequestDto
    {       

        [Required(ErrorMessage = "Por favor, informe o nome do aluno.")]
        public string? Nome { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "Informe um cpf válido com pontos e traço. Ex: 111.222.333-44")]
        [Required(ErrorMessage = "Por favor, informe o Cpf do aluno.")]
        public string? Cpf { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do aluno.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe o ID da turma. ")]
        public Guid? TurmaId { get; set; }
    }
}
