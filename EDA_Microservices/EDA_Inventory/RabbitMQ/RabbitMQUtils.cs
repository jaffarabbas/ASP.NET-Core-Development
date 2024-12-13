using System.Text;
using RabbitMQ.Client;

namespace EDA_Inventory.RabbitMQ;

public class RabbitMQUtils : IRabbitMQUtils
{
    public async Task PublishMessageQueue(string routingKey, string eventData)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        var body = Encoding.UTF8.GetBytes(eventData);
        channel.BasicPublish(exchange: "topic.exchange", routingKey: routingKey, basicProperties: null,body: body);
        await Task.CompletedTask;
    }
}