using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Domain.Models.Entities;
using CursoApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public Aluno? GetById(Guid alunoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Aluno>()
                    .Where(a => a.Id == alunoId)
                    .FirstOrDefault();
            }
        }

        public bool Verify(string email)
        {
            using (var dataContext= new DataContext())
            {
                return dataContext.Set<Aluno>()
                    .Any(a => a.Email.Equals(email));
            }
        }
    }
}
