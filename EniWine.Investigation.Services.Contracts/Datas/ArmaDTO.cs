using System.Runtime.Serialization;

namespace EniWine.Investigation.Services.Contracts.Datas
{
    [DataContract]
    public class ArmaDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
    }
}
