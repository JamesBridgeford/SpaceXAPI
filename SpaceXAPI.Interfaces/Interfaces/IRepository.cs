using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpaceXAPI.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {       
        IQueryable<T> Query();
        IQueryable<T> All(params Expression<Func<T, object>>[] includePaths);
        IQueryable<T> AllReadOnly(params Expression<Func<T, object>>[] includePaths);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePaths);
        T ById(object Id);
    }
}
