namespace AbstractFactory
{
    public interface IFactory
    {
        IDataReader GetReader();

        IDataWriter GetWriter();
    }
}