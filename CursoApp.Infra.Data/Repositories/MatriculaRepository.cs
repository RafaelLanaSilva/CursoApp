using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Domain.Models.Entities;
using CursoApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Infra.Data.Repositories
{
    public class MatriculaRepository : BaseRepository<Matricula>, IMatriculaRepository
    {
        public void Delete(Guid turmaId, Guid alunoId)
        {
            using(var datacontext= new DataContext())
            {
                var matricula = datacontext.Set<Matricula>().FirstOrDefault(m => m.TurmaId == turmaId && m.AlunoId == alunoId);

                if(matricula != null)
                {
                    datacontext.Set<Matricula>().Remove(matricula);
                    datacontext.SaveChanges();
                }
            }
        }

        public Matricula? GetById(Guid turmaId, Guid alunoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .FirstOrDefault(m => m.TurmaId == turmaId && m.AlunoId == alunoId);
            }
        }

        public int? QuantidadeMatricular(Guid turmaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .Count(m => m.TurmaId == turmaId);
            }
        }

        public bool VerificarAluno(Guid alunoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .Count(m => m.AlunoId == alunoId) > 0;
            }
        }

        public bool VerificarTurma(Guid turmaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Matricula>()
                    .Count(m => m.TurmaId == turmaId) > 0;
            }
        }
    }
}
