using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AbstractFactory
{
    public class JsonWritter : IDataWriter
    {
        private string fileName = @"C:\FactoryFileJson.txt";

        public User Add(string name, int age, string city)
        {
            var users = new List<User>();
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                City = city
            };
            users.Add(user);
            File.WriteAllText(fileName, JsonConvert.SerializeObject(users));
            //using (StreamWriter file = new StreamWriter(fileName))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, users);
            //}
            return user;
        }

        public User Delete(Guid id)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<User>>(json);
                var removeItem = items.Single(i => i.Id == id);
                items.Remove(removeItem);
                File.WriteAllText(fileName, JsonConvert.SerializeObject(items));
                return removeItem;
            }
        }
    }
}