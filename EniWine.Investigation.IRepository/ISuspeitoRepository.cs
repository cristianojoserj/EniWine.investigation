using EniWine.Core.Repositories.Repositories;
using EniWine.Investigation.Models;

namespace EniWine.Investigation.Repository.Interface
{
    public interface ISuspeitoRepository : IRepository<Suspeito>
    {
        Suspeito LoadById(int id);
    }
}
