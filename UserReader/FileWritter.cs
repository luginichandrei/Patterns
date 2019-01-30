using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AbstractFactory
{
    public class FileWriter : IDataWriter
    {
        private string fileName = @"C:\DataInfo.txt";

        public User Add(string name, int age, string city)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Age = age,
                City = city
            };
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Id:{0},Name:{1},Age:{2},City:{3};", user.Id, user.Name, user.Age, user.City);
            }
            return user;
        }

        public User Delete(Guid id)
        {
            var users = new List<User>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] items = reader.ReadToEnd().Split("\r\n");

                    foreach (var fields in items)
                    {
                        string[] item = fields.Split(",");
                        var user = new User()
                        {
                            Id = new Guid(item[0].Split(":").Last()),
                            Name = item[1].Split(":").Last(),
                            Age = Int32.Parse(item[2].Split(":").Last()),
                            City = item[3].Split(":").Last()
                        };
                        users.Add(user);
                    }
                }
            }
            var removeItem = users.Single(i => i.Id == id);
            users.Remove(removeItem);
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                foreach (var user in users) {
                    sw.WriteLine("Id:{0},Name:{1},Age:{2},City:{3};", user.Id, user.Name, user.Age, user.City);
                }
            }
            return removeItem;
        }
    }
}