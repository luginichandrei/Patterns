using System;

namespace AbstractFactory
{
    public interface IDataWriter
    {
        User Add(string name, int age, string city);

        User Delete(Guid Id);
    }
}