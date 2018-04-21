using System.Collections.Generic;

namespace EniWine.Core.Repositories.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity model);
        void Insert(IList<TEntity> entities);
        void Update(TEntity model);
        void Update(IList<TEntity> entities);
        TEntity SaveOrUpdate(TEntity model);
        void Delete(TEntity model);
        void Delete(IList<TEntity> entities);
        void Delete(int id);
        void Delete(long id);
        void Delete(string id);
    }
}
