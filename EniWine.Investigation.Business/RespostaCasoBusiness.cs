using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.IRepository;
using EniWine.Investigation.Models;

namespace EniWine.Investigation.Business
{
    public class RespostaCasoBusiness : IRespostaCasoBusiness
    {
        #region [ Atributos ]

        private readonly IRespostaCasoRepository _repository;

        #endregion [ Atributos ]

        #region [ Construtor ]

        public RespostaCasoBusiness(IRespostaCasoRepository repository)
        {
            _repository = repository;
        }

        #endregion [ Construtor ]

        public void SetNewCase(RespostaCaso model)
        {
            var modelList = _repository.LoadAll();
            foreach (var item in modelList)
            {
                _repository.Delete(item.Id);
            }

            _repository.Insert(model);
        }

        public int TestCase(string resposta)
        {
            var modelList = _repository.LoadAll();

            string[] vendas = resposta.Split(',');

            if (modelList[0].Arma.ToString() != vendas[0])
                return 1;
            if (modelList[0].Local.ToString() != vendas[1])
                return 2;
            if (modelList[0].Suspeito.ToString() != vendas[2])
                return 3;

            return 0;
        }
    }
}
