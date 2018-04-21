using Microsoft.Practices.Unity;
using System;

namespace EniWine.Core.Repositories.IoC
{
    public sealed class DependencyInjectionContainer
    {
        private IUnityContainer _container;
        private static DependencyInjectionContainer _instance;

        private DependencyInjectionContainer()
        {
            LoadDependences();
        }

        private void LoadDependences()
        {
            _container = new UnityContainer();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>(new ResolverOverride[0]);
        }

        public IUnityContainer RegisterType(Type from, Type to)
        {
            return _container.RegisterType(from, to);
        }

        public static DependencyInjectionContainer Instance
        {
            get { return _instance ?? (_instance = new DependencyInjectionContainer()); }
        }

    }
}
