namespace AbstractFactory
{
    public class FileFactory : IFactory
    {
        public IDataReader GetReader()
        {
            return new FileReader();
        }

        public IDataWriter GetWriter()
        {
            return new FileWriter();
        }
    }
}