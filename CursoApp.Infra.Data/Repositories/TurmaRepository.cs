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
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public Turma? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Turma>()
                    .Where(t => t.Id == id)
                    .FirstOrDefault();
            }
        }

    }
}
