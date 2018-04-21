using EniWine.Investigation.Models;
using System.Collections.Generic;

namespace EniWine.Investigation.Business.Interface
{
    public interface IArmaBusiness
    {
        Arma LoadById(int id);
        IList<Arma> LoadAll();
    }
}
