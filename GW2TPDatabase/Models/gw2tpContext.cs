using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GW2TPDatabase.Models.Mapping;

namespace GW2TPDatabase.Models
{
    public partial class gw2tpContext : DbContext
    {
        static gw2tpContext()
        {
            Database.SetInitializer<gw2tpContext>(null);
        }

        public gw2tpContext()
            : base("Name=gw2tpContext")
        {
        }

        public DbSet<itemdetail> itemdetails { get; set; }
        public DbSet<pricedata> pricedatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new itemdetailMap());
            modelBuilder.Configurations.Add(new pricedataMap());
        }
    }
}
