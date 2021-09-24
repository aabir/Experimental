using PostGreBE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Service
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T GetById(Guid id);
        //T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
