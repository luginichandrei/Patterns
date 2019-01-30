using System;
using System.IO;

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
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine("Id:{0},Name:{1},Age:{2},City:{3};", user.Id, user.Name, user.Age, user.City);
            }
            return user;
        }

        public User Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}