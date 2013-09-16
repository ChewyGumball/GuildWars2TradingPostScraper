using System;
using System.Collections.Generic;

namespace GW2TPDatabase.Models
{
    public partial class pricedata
    {
        public long apiID { get; set; }
        public System.DateTime lastPriceCheck { get; set; }
        public System.DateTime lastPriceUpdate { get; set; }
        public Nullable<long> maxBuyPrice { get; set; }
        public Nullable<long> minSellPrice { get; set; }
        public Nullable<long> sellSupply { get; set; }
        public Nullable<long> buyDemand { get; set; }
    }
}
