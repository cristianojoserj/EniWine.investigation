using EniWine.Investigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniWine.Investigation.Business.Interface
{
    public interface IRespostaCasoBusiness
    {
        void SetNewCase(RespostaCaso model);
        int TestCase(string resposta);
    }
}
