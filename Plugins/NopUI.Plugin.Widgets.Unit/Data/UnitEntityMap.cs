using System.Data.Entity.ModelConfiguration;
using NopUI.Plugin.Widgets.Unit.Domain;

namespace NopUI.Plugin.Widgets.Unit.Data
{
    public partial class UnitEntityMap : EntityTypeConfiguration<UnitEntity>
    {
        public UnitEntityMap()
        {
            this.ToTable("ehuahai_ProductUnit");
            this.HasKey(x => x.Id);
            this.Property(p => p.Name).IsRequired().HasMaxLength(400);
            this.Property(p => p.DisplayOrder);
        }
    }
}