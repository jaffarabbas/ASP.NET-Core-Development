
using RabbitMQ.Client;

namespace EDA_Customer.RabbitMQ;

public interface IRabbitMQUtils
{
    Task PublishMessageQueue(string routingKey, string eventData);
    Task ListenMessageQueue(IModel channel,string routingKey, CancellationToken cancellationToken);
}