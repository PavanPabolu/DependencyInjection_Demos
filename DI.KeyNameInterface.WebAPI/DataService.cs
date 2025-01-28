namespace DI.KeyNameInterface.WebAPI
{
    public interface IDataService
    {
        string GetMessage();
    }

    public class LocalDataService : IDataService
    {
        public string GetMessage() => "Hello from Local Service!";
    }

    public class CloudDataService : IDataService
    {
        public string GetMessage() => "Hello from Cloud Service!";
    }
}
