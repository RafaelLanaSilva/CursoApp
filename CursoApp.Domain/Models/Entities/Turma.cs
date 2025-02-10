using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Models.Entities
{
    public class Turma
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Numero { get; set; }
        public string? AnoLetivo { get; set; }

        #endregion

        #region Relacionamentos
        public List<Matricula>? Matriculas { get; set; }
        public Nivel? Nivel { get; set; }

        #endregion
    }

    public enum Nivel
    {
        Basico = 1,
        Intermediario = 2,
        Avancado = 3
    }
}
