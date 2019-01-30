using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AbstractFactory
{
    public class FileReader : IDataReader
    {
        private string fileName = @"C:\DataInfo.txt";

        public virtual List<User> All()
        {
            var users = new List<User>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] items = reader.ReadToEnd().Split("\r\n");

                    foreach (var fields in items)
                    {
                        if (fields == "") return users;
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
            return users;
        }

        public List<User> ByCity(string city)
        {
            var users = new List<User>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] lines = reader.ReadToEnd().Split("\r\n");

                    foreach (var fields in lines)
                    {
                        if (fields == "") return users;
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
            return users.Where(u => u.City == city).ToList();
        }
    }
}