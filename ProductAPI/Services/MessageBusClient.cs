using ProductAPI.Models;
using ProductAPI.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ProductAPI.Services
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        public void PublishNewProduct(Product product)
        {
            var message = JsonSerializer.Serialize(product);

            if (_connection.IsOpen)
            {
                SendMessage(message);
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "trigger",
                            routingKey: "",
                            basicProperties: null,
                            body: body);
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
    }
}
