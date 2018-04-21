using EniWine.Investigation.Services.Contracts.Datas;
using System.Collections.Generic;
using System.ServiceModel;

namespace EniWine.Investigation.Services.Contracts
{
    [ServiceContract]
    public interface IInvestigationService
    {
        [OperationContract]
        ArmaDTO ObterArmaPorId(int id);

        [OperationContract]
        IList<ArmaDTO> ObterArmas();
    }
}
