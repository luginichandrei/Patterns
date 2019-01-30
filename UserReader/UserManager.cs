using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual User Delete(Guid id)
        {
            var result = factory.GetWriter().Delete(id);
            return result;
        }

        public virtual List<User> ByAge(int age) => factory.GetReader().All().Where(x => x.Age == age).ToList();
    }
}