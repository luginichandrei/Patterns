namespace AbstractFactory
{
    public class JsonFactory : IFactory
    {
        public IDataReader GetReader()
        {
            return new JsonReader();
        }

        public IDataWriter GetWriter()
        {
            return new JsonWritter();
        }
    }
}