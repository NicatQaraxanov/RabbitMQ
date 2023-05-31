using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
    public interface IMessageBusClient
    {
        void PublishNewProduct(Product product);
    }
}
