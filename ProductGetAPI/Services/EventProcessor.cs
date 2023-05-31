using ProductGetAPI.Models;
using ProductGetAPI.Models.Statics;
using ProductGetAPI.Services.Interfaces;
using System.Text.Json;

namespace ProductGetAPI.Services
{
    public class EventProcessor : IEventProcessor
    {
        public void ProcessEvent(string message)
        {
            AddProduct(message);
        }

        private void AddProduct(string productPublishedMessage)
        {
            var productPublished = JsonSerializer.Deserialize<Product>(productPublishedMessage);

            try
            {
                StaticProductList.Products.Add(productPublished);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not add Product to DB {ex.Message}");
            }
        }
    }
}
