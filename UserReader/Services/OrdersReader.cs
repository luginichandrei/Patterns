using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UserReader.Models;

namespace UserReader.Services
{
    public class OrdersReader
    {
        public List<CityInfo> LoadFile()
        {
            string myFileName = @"C:\CityInfo.txt";
            using (StreamReader r = new StreamReader(myFileName))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<CityInfo>>(json);

                return items;
            }
        }
    }
}