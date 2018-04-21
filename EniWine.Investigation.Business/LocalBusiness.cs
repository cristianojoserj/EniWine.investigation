using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Repository.Interface;
using EniWine.Investigation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniWine.Investigation.Business
{
    public class LocalBusiness : ILocalBusiness
    {
        #region [ Atributos ]

        private readonly ILocalRepository _repository;

        #endregion [ Atributos ]

        #region [ Construtor ]

        public LocalBusiness(ILocalRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Construtor ]

        public Local LoadById(int id)
        {
            return _repository.LoadById(id);
        }
    }
}
