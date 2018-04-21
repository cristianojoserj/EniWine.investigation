using EniWine.Investigation.Models;

namespace EniWine.Investigation.Business.Interface
{
    public interface ILocalBusiness
    {
        Local LoadById(int id);
    }
}
