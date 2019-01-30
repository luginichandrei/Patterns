using System.Collections.Generic;

namespace AbstractFactory
{
    public interface IDataReader
    {
        List<User> All();

        List<User> ByCity(string city);
    }
}