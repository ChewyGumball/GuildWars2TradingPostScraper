using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GW2TPDatabase.Models.Mapping
{
    public class itemdetailMap : EntityTypeConfiguration<itemdetail>
    {
        public itemdetailMap()
        {
            // Primary Key
            this.HasKey(t => t.apiID);

            // Properties
            this.Property(t => t.apiID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.icon)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("itemdetails", "gw2tp");
            this.Property(t => t.apiID).HasColumnName("apiID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.icon).HasColumnName("icon");
            this.Property(t => t.rarity).HasColumnName("rarity");
            this.Property(t => t.level).HasColumnName("level");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.subtype).HasColumnName("subtype");
            this.Property(t => t.gwID).HasColumnName("gwID");
        }
    }
}
