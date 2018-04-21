using EniWine.Investigation.Models;
using FluentNHibernate.Mapping;

namespace EniWine.Investigation.Map
{
    public class LocalMap : ClassMap<Local>
    {
        public LocalMap()
        {
            Table("CAD_LOCAL");
            Id(x => x.Id, "IDT_LOCAL").GeneratedBy.Native();
            Map(x => x.Nome, "TXT_NOME").Nullable();
        }
    }
}
