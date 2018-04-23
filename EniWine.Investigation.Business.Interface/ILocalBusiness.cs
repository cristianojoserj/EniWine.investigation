using EniWine.Investigation.Models;
using System.Collections.Generic;

namespace EniWine.Investigation.Business.Interface
{
    public interface ILocalBusiness
    {
        Local LoadById(int id);
        IList<Local> LoadAll();
    }
}
