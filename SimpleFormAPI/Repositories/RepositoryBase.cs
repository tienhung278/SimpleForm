using SimpleFormAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleFormAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly List<T> _store;

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _store = _repositoryContext.Set<T>();
        }

        public void Create(T entity)
        {
            _store.Add(entity);
        }

        public void Delete(T entity)
        {
            _store.Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return _store;
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _store.Where(expression.Compile());
        }

        public void Update(T entity)
        {
            var updatedObj = entity as dynamic;
            var currentObj = _store.Single(o => (o as dynamic).Id == updatedObj.Id) as dynamic;
            currentObj.FirstName = updatedObj.FirstName;
            currentObj.LastName = updatedObj.LastName;
        }
    }
}
