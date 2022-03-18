using PodcastManager.Api.CrossCutting.Rabbit;
using PodcastManager.Api.Definitions;
using RabbitMQ.Client;

namespace PodcastManager.Api;

public static class ConfigurationExtensions
{
    public static IApplicationBuilder SetUp(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();

        app.UseEndpointDefinitions();
        
        return app;
    }
    
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddBaseIoC()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddEndpointDefinitions(typeof(Program));
        
        return builder;
    }

    private static IServiceCollection AddBaseIoC(this IServiceCollection service)
    {
        return service
            .AddSingleton<IConnectionFactory>(_ => new ConnectionFactory {Uri = new Uri(RabbitConfiguration.Host)});
    }
}