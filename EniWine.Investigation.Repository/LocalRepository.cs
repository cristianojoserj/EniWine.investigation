using EniWine.Core.Repositories.Repositories;
using EniWine.Investigation.Repository.Interface;
using EniWine.Investigation.Models;

namespace EniWine.Investigation.Repository
{
    public class LocalRepository : Repository<Local>, ILocalRepository
    {
    }
}
