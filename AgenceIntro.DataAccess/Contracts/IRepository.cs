using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgenceIntro.DataAccess.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T entity);

        void Delete(T entity);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        T Update(T entity);

        IQueryable<T> GetAll();
    }
}
