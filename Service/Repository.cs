using Microsoft.EntityFrameworkCore;
using PostGreBE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(AppDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking();
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        //public T Get(Guid id)
        //{
        //    return entities.SingleOrDefault(s => s.Id == id);
        //}
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }


    }
}
