using PodcastManager.Api.CrossCutting.Rabbit;
using PodcastManager.Api.Definitions;
using RabbitMQ.Client;

namespace PodcastManager.Api.Modules;

public class GeneralEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
    }

    public void DefineServices(IServiceCollection services)
    {
        services
            .AddSingleton<IEnqueuerAdapter>(s =>
            {
                var adapter = new RabbitEnqueuerAdapter();
                var factory = s.GetService<IConnectionFactory>()!;
                adapter.SetConnection(factory.CreateConnection());
                return adapter;
            });
    }
}