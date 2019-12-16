using AgenceIntro.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgenceIntro.DataAccess.RepositoryImpl
{
    public class SqlRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;

        public SqlRepository(DbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate);
        }

        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }
    }
}
