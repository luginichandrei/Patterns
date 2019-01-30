using System;
using System.Collections.Generic;
using UserReader.Interfaces;
using UserReader.Models;

namespace UserReader.Services
{
    public class UserManager
    {
        private string source;
        private IDataProvider provider;

        public UserManager(IDataProvider provider, string source)
        {
            this.provider = provider;
            this.source = source;
        }

        public List<UserInfo> GetAll()
        {
            Console.WriteLine("UserManager: GetAll");
            return provider.FromFile();
        }

        public void AddUser(UserInfo userInfo)
        {
            Console.WriteLine("UserManager: AddUser");
            provider.AddUser(userInfo);
        }
    }
}