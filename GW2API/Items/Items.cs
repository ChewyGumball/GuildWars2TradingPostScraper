using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using GW2API.Common;

namespace GW2API.Items
{
    public static class Items
    {
        private static readonly string itemIDListFileName = "itemIDs.txt";
        private static readonly string itemListAPI = "https://api.guildwars2.com/v1/items.json";

        private static IList<Item> itemList;
        private static Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();


        public static void sortItems()
        {
            
            List<Item> before = readItemIDFile("itemIDsoriginal.txt");
            List<Item> after = readItemIDFile("itemIDs.txt");
            before.OrderBy(e => e.ID);
            after.OrderBy(e => e.ID);


            if (after == before)
            {
                Console.Out.Write("AH");
            }
            using (TextWriter file = File.CreateText(getFullFilePath("superfast.txt")))
            {
                for (int i = 0; i < before.Count; i++)
                {
                    if(after[i].maxOffer != 0)
                    if (after[i].maxOffer - before[i].maxOffer != 0)
                    {
                        file.WriteLine("{0} : {1}", before[i].name, after[i].maxOffer - before[i].maxOffer);
                    }
                }
            }

            /*
            DateTime lastWeek = DateTime.Now.AddDays(-7);
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime lastFiveHours = DateTime.Now.AddHours(-5);
            IEnumerable<Item> recentItems = itemList.Where(e => DateTime.Parse(e.priceLastChanged).CompareTo(lastWeek) > 0);
            IEnumerable<Item> fastItems = recentItems.Where(e => DateTime.Parse(e.priceLastChanged).CompareTo(yesterday) > 0);
            IEnumerable<Item> superFastItems = fastItems.Where(e => DateTime.Parse(e.priceLastChanged).CompareTo(lastFiveHours) > 0);

            Console.Out.Write("{0} items in last week, {1} items in last day, {2} items in last five hours.", recentItems.Count(), fastItems.Count(), superFastItems.Count());

            using (TextWriter file = File.CreateText(getFullFilePath("superfast.txt")))
            {
                foreach (Item i in superFastItems.OrderBy(e => DateTime.Parse(e.priceLastChanged)))
                {
                    file.WriteLine("{0} : {1} : {2}", i.ID, i.name, i.priceLastChanged);
                }
            }
             * */


        }

        private static List<Item> readItemIDFile(string filename)
        {
            using (StreamReader stream = File.OpenText(getFullFilePath(filename)))
            {
                return convertFromJson(stream);
            }
        }

        public static List<Item> convertFromJson(string json)
        {
            using (StringReader stream = new StringReader(json))
            {
                return convertFromJson(stream);
            }
        }

        public static List<Item> convertFromJson(TextReader stream)
        {
            using (JsonReader reader = new JsonTextReader(stream))
            {
                JArray itemArray = JObject.Load(reader)["results"] as JArray;
                List<Item> itemList = itemArray.ToObject<List<Item>>();

                return itemList;
            }
        }

        private static void updateItemIDFile()
        {
            string fullFileName = getFullFilePath(itemIDListFileName);
            if (!File.Exists(fullFileName))
            {
                //API.downloadFile(itemListAPI, fullFileName);
            }
        }

        private static string getFullFilePath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

    }
}
