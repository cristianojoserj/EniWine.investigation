using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Repository.Interface;
using EniWine.Investigation.Models;
using System.Collections.Generic;

namespace EniWine.Investigation.Business
{
    public class ArmaBusiness : IArmaBusiness
    {
        #region [ Atributos ]

        private readonly IArmaRepository _repository;

        #endregion [ Atributos ]

        #region [ Construtor ]

        public ArmaBusiness(IArmaRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Construtor ]

        public Arma LoadById(int id)
        {
            return _repository.LoadById(id);
        }

        public IList<Arma> LoadAll()
        {
            return _repository.LoadAll();
        }
    }
}
