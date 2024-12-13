using System.Text;
using EDA_Customer.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EDA_Customer.RabbitMQ;

public class RabbitMQUtils(IServiceScopeFactory serviceScopeFactory) : IRabbitMQUtils
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

    public async Task ListenMessageQueue(IModel channel,string routingKey,CancellationToken cancellationToken)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = Encoding.UTF8.GetString(ea.Body.ToArray());
            await ParseInventoryProductMessage(body,ea,cancellationToken);
        };
        channel.BasicConsume(queue: "inventory.product", autoAck: true, consumer: consumer);
        await Task.CompletedTask;
    }

    private async Task ParseInventoryProductMessage(string message, BasicDeliverEventArgs ea,
        CancellationToken cancellationToken)
    {
        using var scope = serviceScopeFactory.CreateScope();
        var customerDBContext = scope.ServiceProvider.GetRequiredService<CustomerDBContext>();

        var data = JObject.Parse(message);
        var type = ea.RoutingKey;

        if (type == "inventory.product")
        {
            var guidValue = Guid.Parse(data["ProductID"].Value<string>());
            var product =
                await customerDBContext.Products.FirstOrDefaultAsync(a => a.ProdcutID == guidValue, cancellationToken);

            if (product != null)
            {
                product.Name = data["ProductName"].Value<string>();
                product.Quantity = data["Quantity"].Value<int>();
            }
            else
            {
                await customerDBContext.Products.AddAsync(new Product()
                {
                    id = data["ID"].Value<int>(),
                    ProdcutID = guidValue,
                    Name = data["Name"].Value<string>(),
                    Quantity = data["Quantity"].Value<int>()
                }, cancellationToken);
                await customerDBContext.SaveChangesAsync(cancellationToken);
                await Task.Delay(new Random().Next(1,3) * 1000, cancellationToken);
            }
        }
    }
}