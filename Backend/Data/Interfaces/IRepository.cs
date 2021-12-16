using System.Collections.Generic;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int query);
        void Save();
        void Update(TEntity entity);
    }
}