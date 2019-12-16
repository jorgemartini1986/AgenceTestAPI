using AgenceIntro.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgenceIntro.DataAccess.Contracts
{
    public interface IUserRepository
    {
        void Add(CaoUsuario entity);

        void Delete(CaoUsuario entity);

        IQueryable<CaoUsuario> Find(Expression<Func<CaoUsuario, bool>> predicate);

        IQueryable<CaoUsuario> Find(string predicate);

        IQueryable<CaoUsuario> GetAll();

        CaoUsuario Get(string coUsuario);
    }
}
