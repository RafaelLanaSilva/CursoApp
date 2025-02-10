using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                var entity = dataContext.Set<T>().Find(id);

                if (entity != null)
                {
                    dataContext.Remove(entity);
                    dataContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("Entidade não encontrada para exclusão.");
                }
            }
        }

        public List<T> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<T>().ToList();
            }
        }

    }
}
