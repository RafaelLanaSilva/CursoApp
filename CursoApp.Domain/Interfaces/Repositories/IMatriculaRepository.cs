using CursoApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Interfaces.Repositories
{
    public interface IMatriculaRepository : IBaseRepository<Matricula>
    {
        void Delete(Guid turmaId, Guid alunoId);
        Matricula? GetById(Guid turmaId, Guid alunoId);
        int? QuantidadeMatricular(Guid turmaId);

        bool VerificarAluno(Guid alunoId);
        bool VerificarTurma(Guid turmaId);
    }
}
