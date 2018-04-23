using EniWine.Investigation.Models;
using System.Collections.Generic;

namespace EniWine.Investigation.Business.Interface
{
    public interface ISuspeitoBusiness
    {
        Suspeito LoadById(int id);
        IList<Suspeito> LoadAll();
    }
}
