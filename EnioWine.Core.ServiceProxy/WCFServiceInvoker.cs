using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EnioWine.Core.ServiceProxy
{
    public class WCFServiceInvoker : IServiceInvoker
    {

        private const string SectionClientWcf = "system.serviceModel/client";
        private static readonly ChannelFactoryManager FactoryManager = new ChannelFactoryManager();
        private static readonly ClientSection ClientSection = ConfigurationManager.GetSection(SectionClientWcf) as ClientSection;

        public R InvokeService<T, R>(Func<T, R> invokeHandler) where T : class
        {
            var endpointNameAddressPair = GetEndpointNameAddressPair(typeof(T));
            var arg = FactoryManager.CreateChannel<T>(endpointNameAddressPair.Key, endpointNameAddressPair.Value);
            var obj2 = (ICommunicationObject)arg;

            try
            {
                return invokeHandler(arg);
            }
            finally
            {
                try
                {
                    if (obj2.State != CommunicationState.Faulted)
                        obj2.Close();
                }
                catch
                {
                    obj2.Abort();
                }
            }
        }

        public void InvokeService<T>(Action<T> invokeHandler) where T : class
        {
            var endpointNameAddressPair = GetEndpointNameAddressPair(typeof(T));
            var arg = FactoryManager.CreateChannel<T>(endpointNameAddressPair.Key, endpointNameAddressPair.Value);
            var obj2 = (ICommunicationObject)arg;

            try
            {
                invokeHandler(arg);
            }
            finally
            {
                try
                {
                    if (obj2.State != CommunicationState.Faulted)
                        obj2.Close();
                }
                catch
                {
                    obj2.Abort();
                }
            }
        }

        private KeyValuePair<string, string> GetEndpointNameAddressPair(Type serviceContractType)
        {
            var configException = new ConfigurationErrorsException(string.Format("No client endpoint found for type {0}. Please add the section <client><endpoint name=\"myservice\" address=\"http://address/\" binding=\"basicHttpBinding\" contract=\"{0}\"/></client> in the config file.", serviceContractType));

            if (((ClientSection == null) || (ClientSection.Endpoints == null)) || (ClientSection.Endpoints.Count < 1))
                throw configException;

            foreach (ChannelEndpointElement element in ClientSection.Endpoints)
            {
                if (element.Contract == serviceContractType.ToString())
                    return new KeyValuePair<string, string>(element.Name, element.Address.AbsoluteUri);
            }

            throw configException;
        }
    }
}
