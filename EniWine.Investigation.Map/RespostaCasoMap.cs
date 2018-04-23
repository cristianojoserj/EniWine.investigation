using EniWine.Investigation.Models;
using FluentNHibernate.Mapping;

namespace EniWine.Investigation.Map
{
    public class RespostaCasoMap : ClassMap<RespostaCaso>
    {
        public RespostaCasoMap()
        {
            Table("CAD_RESPOSTA");
            Id(x => x.Id, "IDT_RESPOSTA").GeneratedBy.Native();
            Map(x => x.Arma, "IDT_ARMA").Nullable();
            Map(x => x.Local, "IDT_LOCAL").Nullable();
            Map(x => x.Suspeito, "IDT_SUSPEITO").Nullable();
        }
    }
}
