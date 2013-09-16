using System;
using System.Collections.Generic;

namespace GW2TPDatabase.Models
{
    public partial class itemdetail
    {
        public long apiID { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public Nullable<long> rarity { get; set; }
        public Nullable<long> level { get; set; }
        public Nullable<long> type { get; set; }
        public Nullable<long> subtype { get; set; }
        public long gwID { get; set; }
    }
}
