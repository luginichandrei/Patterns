using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AbstractFactory
{
    public class JsonReader : IDataReader
    {
        private string fileName = @"C:\FactoryFileJson.txt";

        public List<User> All()
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<User>>(json);

                return items;
            }
        }

        public List<User> ByCity(string city)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<User>>(json);

                return items.Where(c => c.City == city).ToList();
            }
        }
    }
}