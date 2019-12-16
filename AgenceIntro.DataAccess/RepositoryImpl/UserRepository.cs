using AgenceIntro.Core.Models;
using AgenceIntro.DataAccess.Contracts;
using AgenceIntro.EntityFramework.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgenceIntro.DataAccess.RepositoryImpl
{
    public class UserRepository : IUserRepository
    {
        private readonly AgenceDbContext context;

        public UserRepository(AgenceDbContext context)
        {
            this.context = context;
        }
        
        public void Add(CaoUsuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CaoUsuario entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CaoUsuario> Find(Expression<Func<CaoUsuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CaoUsuario> Find(string predicate)
        {
            throw new NotImplementedException();
        }

        public CaoUsuario Get(string coUsuario)
        {
            return context.CaoUsuario.FirstOrDefault(user => user.CoUsuario == coUsuario);
        }

        public IQueryable<CaoUsuario> GetAll()
        {
            return context.CaoUsuario;
        }
    }
}
