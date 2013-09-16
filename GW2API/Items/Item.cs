using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GW2API.Items
{
    //Official
    //http://wiki.guildwars2.com/wiki/API:1/item_details

    //gw2spidy
    //https://github.com/rubensayshi/gw2spidy/wiki/API-v0.9#item-data
    public class Item
    {
        [JsonProperty("data_id")]
        public int ID { get; private set; }

        [JsonProperty("name")]
        public string name { get; private set; }

        [JsonProperty("rarity")]
        public int rarity { get; private set; }

        [JsonProperty("restriction_level")]
        public int level { get; private set; }

        [JsonProperty("img")]
        public string iconURL { get; private set; }

        [JsonProperty("type_id")]
        public int type { get; private set; }

        [JsonProperty("sub_type_id")]
        public int subType { get; private set; }

        [JsonProperty("price_last_changed")]
        [JsonConverter(typeof(GW2SpidyDateTimeConverter))]
        public DateTime priceLastChanged { get; private set; }

        [JsonProperty("max_offer_unit_price")]
        public int maxOffer { get; private set; }

        [JsonProperty("min_sale_unit_price")]
        public int minSale { get; private set; }

        [JsonProperty("offer_availability")]
        public int buyCount { get; private set; }

        [JsonProperty("sale_availability")]
        public int saleCount { get; private set; }

        [JsonProperty("gw2db_external_id")]
        public int officialID { get; private set; }

        [JsonProperty("sale_price_change_last_hour")]
        public int salePriceChangePercent { get; private set; }

        [JsonProperty("offer_price_change_last_hour")]
        public int buyPriceChangePercent { get; private set; }
    }
}
