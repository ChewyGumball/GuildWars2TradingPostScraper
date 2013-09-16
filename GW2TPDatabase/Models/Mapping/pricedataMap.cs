using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GW2TPDatabase.Models.Mapping
{
    public class pricedataMap : EntityTypeConfiguration<pricedata>
    {
        public pricedataMap()
        {
            // Primary Key
            this.HasKey(t => new { t.apiID, t.lastPriceCheck });

            // Properties
            this.Property(t => t.apiID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("pricedata", "gw2tp");
            this.Property(t => t.apiID).HasColumnName("apiID");
            this.Property(t => t.lastPriceCheck).HasColumnName("lastPriceCheck");
            this.Property(t => t.lastPriceUpdate).HasColumnName("lastPriceUpdate");
            this.Property(t => t.maxBuyPrice).HasColumnName("maxBuyPrice");
            this.Property(t => t.minSellPrice).HasColumnName("minSellPrice");
            this.Property(t => t.sellSupply).HasColumnName("sellSupply");
            this.Property(t => t.buyDemand).HasColumnName("buyDemand");
        }
    }
}
