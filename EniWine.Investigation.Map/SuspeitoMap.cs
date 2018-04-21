using FluentNHibernate.Mapping;
using EniWine.Investigation.Models;

namespace EniWine.Investigation.Map
{
    class SuspeitoMap : ClassMap<Suspeito>
    {
        public SuspeitoMap()
        {
            Table("CAD_SUSPEITO");
            Id(x => x.Id, "IDT_SUSPEITO").GeneratedBy.Native();
            Map(x => x.Nome, "TXT_NOME").Nullable();
        }
    }
}
