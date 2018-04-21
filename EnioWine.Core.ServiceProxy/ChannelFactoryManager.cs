using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EnioWine.Core.ServiceProxy
{
    public class ChannelFactoryManager : IDisposable
    {
        private static readonly Dictionary<Type, ChannelFactory> Factories = new Dictionary<Type, ChannelFactory>();
        private static readonly object SyncRoot = new object();

        public virtual T CreateChannel<T>() where T : class
        {
            return CreateChannel<T>("*", null);
        }

        public virtual T CreateChannel<T>(string endpointConfigurationName) where T : class
        {
            return CreateChannel<T>(endpointConfigurationName, null);
        }

        public virtual T CreateChannel<T>(string endpointConfigurationName, string endpointAddress) where T : class
        {
            T local = GetFactory<T>(endpointConfigurationName, endpointAddress).CreateChannel();
            ((IClientChannel)local).Faulted += ChannelFaulted;
            return local;
        }

        protected virtual ChannelFactory<T> GetFactory<T>(string endpointConfigurationName, string endpointAddress) where T : class
        {
            lock (SyncRoot)
            {
                ChannelFactory factory;
                if (!Factories.TryGetValue(typeof(T), out factory))
                {
                    factory = CreateFactoryInstance<T>(endpointConfigurationName, endpointAddress);
                    Factories.Add(typeof(T), factory);
                }
                return (factory as ChannelFactory<T>);
            }
        }

        private ChannelFactory CreateFactoryInstance<T>(string endpointConfigurationName, string endpointAddress)
        {
            ChannelFactory factory = !string.IsNullOrEmpty(endpointAddress)
                                         ? new ChannelFactory<T>(endpointConfigurationName, new EndpointAddress(endpointAddress))
                                         : new ChannelFactory<T>(endpointConfigurationName);

            factory.Faulted += FactoryFaulted;

            factory.Open();
            return factory;
        }

        private void ChannelFaulted(object sender, EventArgs e)
        {
            var channel = (IClientChannel)sender;
            try
            {
                channel.Close();
            }
            catch (Exception)
            {
                channel.Abort();
            }
            throw new ApplicationException("Exc_ChannelFailure");
        }

        private void FactoryFaulted(object sender, EventArgs args)
        {
            var factory = (ChannelFactory)sender;
            try
            {
                factory.Close();
            }
            catch
            {
                factory.Abort();
            }
            var genericArguments = factory.GetType().GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                Type key = genericArguments[0];
                if (Factories.ContainsKey(key))
                {
                    Factories.Remove(key);
                }
            }
            throw new ApplicationException("Exc_ChannelFactoryFailure");
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            lock (SyncRoot)
            {
                foreach (var type in Factories.Keys)
                {
                    var factory = Factories[type];
                    try
                    {
                        factory.Close();
                    }
                    catch
                    {
                        factory.Abort();
                    }
                }
                Factories.Clear();
            }
        }
    }
}
