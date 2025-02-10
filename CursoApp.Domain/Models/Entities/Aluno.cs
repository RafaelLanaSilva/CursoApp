using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Entities
{
    public class Aluno
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }

        #endregion

        #region Relacionamentos

        public List<Matricula>? Matriculas { get; set; }

        #endregion

    }
}
