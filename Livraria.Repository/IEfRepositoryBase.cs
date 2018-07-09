using System.Collections.Generic;

namespace Livraria.Repository
{
    public interface IEfRepositoryBase<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}