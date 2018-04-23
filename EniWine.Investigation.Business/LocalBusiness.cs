using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Models;
using EniWine.Investigation.Repository.Interface;
using System.Collections.Generic;

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
        public IList<Local> LoadAll()
        {
            return _repository.LoadAll();
        }
    }
}
