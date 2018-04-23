using AutoMapper;
using EniWine.Core.Repositories.IoC;
using EniWine.Core.Repositories.Tools;
using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Models;
using EniWine.Investigation.Services.Behaviors;
using EniWine.Investigation.Services.Contracts;
using EniWine.Investigation.Services.Contracts.Datas;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace EniWine.Investigation.Services
{
    [CadastroServiceBehavior]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class InvestigationService : IInvestigationService
    {
        #region [ Atributos ]

        private readonly IArmaBusiness _armaBusiness = DependencyInjectionContainer.Instance.Resolve<IArmaBusiness>();
        private readonly ILocalBusiness _localBusiness = DependencyInjectionContainer.Instance.Resolve<ILocalBusiness>();
        private readonly ISuspeitoBusiness _suspeitoBusiness = DependencyInjectionContainer.Instance.Resolve<ISuspeitoBusiness>();
        private readonly IRespostaCasoBusiness _respostaCasoBusiness = DependencyInjectionContainer.Instance.Resolve<IRespostaCasoBusiness>();

        #endregion [ Atributos ]

        public ArmaDTO ObterArmaPorId(int id)
        {
            return Mapper.Map<ArmaDTO>(_armaBusiness.LoadById(id));
        }
        public IList<ArmaDTO> ObterArmas()
        {
            return Mapper.Map<IList<ArmaDTO>>(_armaBusiness.LoadAll());
        }
        public IList<LocalDTO> ObterLocais()
        {
            return Mapper.Map<IList<LocalDTO>>(_localBusiness.LoadAll());
        }
        public IList<SuspeitoDTO> ObterSuspeitos()
        {
            return Mapper.Map<IList<SuspeitoDTO>>(_suspeitoBusiness.LoadAll());
        }

        public void SetarNovoCaso()
        {
            var respostaCaso = new RespostaCaso();

            var modelListArma = _armaBusiness.LoadAll();
            respostaCaso.Arma = FunctionList.Shuffle(modelListArma).FirstOrDefault().Id;

            var modelListLocal = _localBusiness.LoadAll();
            respostaCaso.Local = FunctionList.Shuffle(modelListLocal).FirstOrDefault().Id;

            var modelListSuspeito = _suspeitoBusiness.LoadAll();
            respostaCaso.Suspeito = FunctionList.Shuffle(modelListSuspeito).FirstOrDefault().Id;

            _respostaCasoBusiness.SetNewCase(respostaCaso);
        }

        public int TestarResposta(string resposta)
        {
            return _respostaCasoBusiness.TestCase(resposta);
        }


    }
}
