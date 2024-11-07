using BaseCoffee.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Repositories
{
    //new constrait araştır bunu yeni gelen özellik
    public interface IRepository <T> where T : BaseEntity, new() 
    {
        DbSet<T> Table { get; }

        public T Add(T entity);
        public T Update(T entity);
        public T Delete(T entity);
        public T Remove(T entity);

        public List<T> AddRange(List<T> entities);

        public IList<T> GetAll();
        public T Get(Expression<Func<T, bool>> predicate);

        public void Save();

        public T Find(int id);
    }
}
