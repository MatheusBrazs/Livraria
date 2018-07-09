using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Livraria.Repository
{
    public abstract class EfRepositoryBase<TEntity, TContext> : IEfRepositoryBase<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context { get; private set; }

        public EfRepositoryBase(TContext context)
        {
            this.Context = context;
        }

        public virtual void Insert(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);

            this.Context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.Context.Set<TEntity>().Update(entity);

            this.Context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);

            this.Context.SaveChanges();
        }

        public virtual TEntity Get(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>();
        }
    }
}
