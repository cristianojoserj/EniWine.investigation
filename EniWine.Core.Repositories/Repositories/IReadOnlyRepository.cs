using System.Collections.Generic;

namespace EniWine.Core.Repositories.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        List<TEntity> LoadAll();

        TEntity FindById(int id);
        TEntity FindById(long id);
        TEntity FindById(string id);

        TEntity LoadById(int id);
        TEntity LoadById(long id);
        TEntity LoadById(string id);
    }
}
