using RabbitMQ.Client;

namespace EDA_Customer.RabbitMQ;

public class RabbitMQService(IRabbitMQUtils rabbitMqUtils) : BackgroundService
{
    private IModel _channel;
    private IConnection _connection;
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            DispatchConsumersAsync = true
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        
        return base.StartAsync(cancellationToken);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await rabbitMqUtils.ListenMessageQueue(_channel,"inventory.product", stoppingToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await base.StopAsync(cancellationToken);
        _connection.Close();
    }
}