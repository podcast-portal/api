using PodcastManager.Api.Definitions;
using PodcastManager.Api.Feed.CrossCutting.IoC;
using PodcastManager.Api.Feed.Domain.Interactors;

namespace PodcastManager.Api.Modules.Feed;

public class FeedEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
    }

    public void DefineServices(IServiceCollection services)
    {
        services
            .AddSingleton(s =>
            {
                var factory = new FeedInteractorFactory();
                factory.SetRepositoryFactory(new FeedRepositoryFactory());
                return factory.CreatePlaylist();
            });
    }
}