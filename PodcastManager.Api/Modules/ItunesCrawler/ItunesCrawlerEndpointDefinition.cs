using Microsoft.AspNetCore.Mvc;
using PodcastManager.Api.Definitions;

namespace PodcastManager.Api.Modules.ItunesCrawler;

public class ItunesCrawlerEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/import/start", ImportStartHandler);
    }

    internal static void ImportStartHandler([FromServices] IEnqueuerAdapter enqueuer) =>
        enqueuer.EnqueueStartCrawl();

    public void DefineServices(IServiceCollection services)
    {
    }
}