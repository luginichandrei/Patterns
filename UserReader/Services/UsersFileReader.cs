using System;
using System.Collections.Generic;
using System.Linq;
using UserReader.Interfaces;
using UserReader.Models;

namespace UserReader.Services
{
    public class UsersFileReader : IDataProvider
    {
        public virtual string Name { get; set; }

        public virtual User AddUser(UserInfo userinfo)
        {
            Console.WriteLine("UsersFileReader: Add user");
            return new User();
        }

        public virtual List<UserInfo> FromFile()
        {
            return ReadUsers().Select(u => new UserInfo()
            {
                Name = u.Name,
                Age = u.Age
            }).ToList();
        }

        public virtual List<User> ReadUsers()
        {
            var users = new List<User>();

            users.Add(new User()
            {
                Name = "Steve",
                Age = 21,
                City = "London"
            });
            users.Add(new User()
            {
                Name = "Mike",
                Age = 41,
                City = "Lviv"
            });

            Console.WriteLine("UsersFileReader: Read users");
            return users;
        }
    }
}