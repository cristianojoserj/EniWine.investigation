using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Repository.Interface;
using EniWine.Investigation.Models;
using System.Collections.Generic;

namespace EniWine.Investigation.Business
{
    public class SuspeitoBusiness: ISuspeitoBusiness
    {
        #region [ Atributos ]

        private readonly ISuspeitoRepository _repository;

        #endregion [ Atributos ]

        #region [ Construtor ]

        public SuspeitoBusiness(ISuspeitoRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Construtor ]

        public Suspeito LoadById(int id)
        {
            return _repository.LoadById(id);
        }
        public IList<Suspeito> LoadAll()
        {
            return _repository.LoadAll();
        }
    }
}
