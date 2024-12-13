namespace EDA_Inventory.RabbitMQ;

public interface IRabbitMQUtils
{
    Task PublishMessageQueue(string routingKey, string eventData);
}