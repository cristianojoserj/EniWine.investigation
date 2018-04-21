using AutoMapper;
using EniWine.Core.Repositories.IoC;
using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Services.Behaviors;
using EniWine.Investigation.Services.Contracts.Datas;
using System.Collections.Generic;
using System.ServiceModel;

namespace EniWine.Investigation.Services
{
    [CadastroServiceBehavior]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class InvestigationService
    {
        #region [ Atributos ]

        private readonly IArmaBusiness _armaBusiness = DependencyInjectionContainer.Instance.Resolve<IArmaBusiness>();
        private readonly ILocalBusiness _localBusiness = DependencyInjectionContainer.Instance.Resolve<ILocalBusiness>();
        private readonly ISuspeitoBusiness _suspeitoBusiness = DependencyInjectionContainer.Instance.Resolve<ISuspeitoBusiness>();

        #endregion [ Atributos ]

        public ArmaDTO ObterArmaPorId(int id)
        {
            return Mapper.Map<ArmaDTO>(_armaBusiness.LoadById(id));
        }
        public IList<ArmaDTO> ObterArmas()
        {
            return Mapper.Map<IList<ArmaDTO>>(_armaBusiness.LoadAll());
        }
    }
}
