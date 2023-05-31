namespace ProductGetAPI.Services.Interfaces
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}
