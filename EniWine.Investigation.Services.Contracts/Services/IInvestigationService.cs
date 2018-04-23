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

        [OperationContract]
        IList<LocalDTO> ObterLocais();

        [OperationContract]
        IList<SuspeitoDTO> ObterSuspeitos();

        [OperationContract]
        void SetarNovoCaso();

        [OperationContract]
        int TestarResposta(string resposta);
    }
}
