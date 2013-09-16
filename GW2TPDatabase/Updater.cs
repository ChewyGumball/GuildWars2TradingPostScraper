using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;



using GW2API.Items;
using GW2TPDatabase.Models;

namespace GW2TPDatabase
{
    class Updater
    {
        private static string fullItemListURI = @"http://www.gw2spidy.com/api/v0.9/json/all-items/all";
        public static void Main()
        {
            updateDatabase();
        }

        private static void updateDatabase()
        {
            while (true)
            {
                DateTime before = DateTime.Now;
                Console.Write("Downloading price data . . . ");
                Item[] items = downloadItemList().ToArray();
                Console.WriteLine("Done.");

                Console.Write("Updating database . . . ");
                using (gw2tpContext database = new gw2tpContext())
                {
                    database.Configuration.AutoDetectChangesEnabled = false;
                    database.Configuration.ValidateOnSaveEnabled = false;

                    for(int i = 0; i < items.Length; i++)
                    {
                        updateItemInDatabase(items[i], database);

                        //save database every 1000 entries for performance reasons
                        if (i % 1000 == 0)
                        {
                            database.SaveChanges();
                        }
                    }
                }
                Console.WriteLine("Done.");
                Thread.Sleep(TimeSpan.FromMinutes(5) - (DateTime.Now - before));
            }
        }

        private static List<Item> downloadItemList()
        {
            using (WebClient client = new WebClient())
            using (StreamReader stream = new StreamReader(client.OpenRead(fullItemListURI)))
            {
                return Items.convertFromJson(stream);
            }
        }

        private static void updateItemInDatabase(Item item, gw2tpContext database)
        {
            database.pricedatas.Add(new pricedata { apiID = item.ID, 
                                                    buyDemand = item.buyCount, 
                                                    maxBuyPrice = item.maxOffer, 
                                                    minSellPrice = item.minSale, 
                                                    sellSupply = item.saleCount, 
                                                    lastPriceUpdate = item.priceLastChanged,
                                                    lastPriceCheck = DateTime.Now.ToUniversalTime() });
        }
    }
}
