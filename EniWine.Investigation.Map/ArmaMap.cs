using EniWine.Investigation.Models;
using FluentNHibernate.Mapping;

namespace EniWine.Investigation.Map
{
    public class ArmaMap: ClassMap<Arma>
    {
        public ArmaMap()
        {
            Table("CAD_ARMA");
            Id(x => x.Id, "IDT_ARMA").GeneratedBy.Native();
            Map(x => x.Nome, "TXT_NOME").Nullable();
        }
    }
}
