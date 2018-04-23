using AutoMapper;
using EniWine.Core.Repositories.IoC;
using EniWine.Investigation.Business;
using EniWine.Investigation.Business.Interface;
using EniWine.Investigation.Repository.Interface;
using EniWine.Investigation.Models;
using EniWine.Investigation.Repository;
using EniWine.Investigation.Services.Contracts.Datas;
using System;
using System.ServiceModel.Description;
using EniWine.Investigation.IRepository;

namespace EniWine.Investigation.Services.Behaviors
{
    public class CadastroServiceBehavior : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            RegisterMapper();
            RegisterDependency();
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            //throw new NotImplementedException();
        }

        #region [ Metodos Privados ]

        private void RegisterMapper()
        {
            Mapper.CreateMap<Arma, ArmaDTO>();
            Mapper.CreateMap<ArmaDTO, Arma>();
            Mapper.CreateMap<Local, LocalDTO>();
            Mapper.CreateMap<LocalDTO, Local>();
            Mapper.CreateMap<Suspeito, SuspeitoDTO>();
            Mapper.CreateMap<SuspeitoDTO, Suspeito>();
        }

        private void RegisterDependency()
        {
            #region [ Repositorio ]

            DependencyInjectionContainer.Instance.RegisterType(typeof(IArmaRepository), typeof(ArmaRepository));
            DependencyInjectionContainer.Instance.RegisterType(typeof(ILocalRepository), typeof(LocalRepository));
            DependencyInjectionContainer.Instance.RegisterType(typeof(ISuspeitoRepository), typeof(SuspeitoRepository));
            DependencyInjectionContainer.Instance.RegisterType(typeof(IRespostaCasoRepository), typeof(RespostaCasoRepository));

            #endregion [ Repositorio ]

            #region [ Negocio ]

            DependencyInjectionContainer.Instance.RegisterType(typeof(IArmaBusiness), typeof(ArmaBusiness));
            DependencyInjectionContainer.Instance.RegisterType(typeof(ILocalBusiness), typeof(LocalBusiness));
            DependencyInjectionContainer.Instance.RegisterType(typeof(ISuspeitoBusiness), typeof(SuspeitoBusiness));
            DependencyInjectionContainer.Instance.RegisterType(typeof(IRespostaCasoBusiness), typeof(RespostaCasoBusiness));

            #endregion [ Negocio ]
        }

        #endregion [ Metodos Privados ]
    }
}