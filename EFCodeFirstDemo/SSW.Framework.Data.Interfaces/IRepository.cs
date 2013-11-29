using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SSW.Framework.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //RETRIEVE METHODS
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Get();

        TEntity Find(object id);


        void LoadCollection<TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> expression)
            where TElement : class;


        void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> expression)
            where TProperty : class;


        //MODIFICATION METHODS
        void Add(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
        //SAVE is not implelented in the repository
        //   because we might want to commit changes to the database from 
        //   multiple repositories, save is called from the EfUnitOfWork

    }
}