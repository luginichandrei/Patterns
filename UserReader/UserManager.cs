using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    public class UserManager
    {
        private IFactory factory;

        public UserManager(IFactory factory)
        {
            this.factory = factory;
        }

        public List<User> GetAll()
        {
            return factory.GetReader().All();
        }

        public void GetByCity(string city)
        {
            var result = factory.GetReader().ByCity(city);
        }

        public void Add(string name, int age, string city)
        {
            var result = factory.GetWriter().Add(name, age, city);
        }

        public void Delete(Guid id)
        {
            var result = factory.GetWriter().Delete(id);
        }
    }
}