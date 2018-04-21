using EniWine.Core.Repositories.Repositories;
using EniWine.Investigation.Models;

namespace EniWine.Investigation.Repository.Interface
{
    public interface ILocalRepository : IRepository<Local>
    {
        Local LoadById(int id);
    }
}
