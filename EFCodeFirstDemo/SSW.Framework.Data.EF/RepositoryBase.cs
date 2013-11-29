using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SSW.Framework.Data.Interfaces;

namespace SSW.Framework.Data.EF
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        protected RepositoryBase(IDbContextManager contextManager)
        {
            if (contextManager == null)
            {
                throw new ArgumentNullException("contextManager");
            }

            ContextManager = contextManager;
            //Context.Configuration.ProxyCreationEnabled = false;
            
            // deferred to delay initialisation of context
           //_dbSet = Context.Set<T>();
        }

        protected IDbContextManager ContextManager { get; private set; }

        protected DbContext Context
        {
            get { return ContextManager.Context; }
        }


        private IDbSet<T> dbSet
        {
            get { return Context.Set<T>(); } 
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return Get().Where(filter);
        }

        public virtual IQueryable<T> Get()
        {
            return dbSet;
        }

        public virtual T Find(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public virtual void LoadCollection<TElement>(T entity, Expression<Func<T, ICollection<TElement>>> expression) where TElement: class
        {
            Context.Entry(entity).Collection(expression).Load();
        }


        public virtual void LoadReference<TProperty>(T entity, Expression<Func<T, TProperty>> expression) where TProperty : class
        {
            Context.Entry(entity).Reference(expression).Load();
        }

    }
}
