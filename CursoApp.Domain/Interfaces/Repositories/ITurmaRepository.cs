using CursoApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Interfaces.Repositories
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        Turma? GetById(Guid id);      
    }
}
