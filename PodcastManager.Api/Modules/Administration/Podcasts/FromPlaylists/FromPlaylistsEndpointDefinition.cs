using Microsoft.AspNetCore.Mvc;
using PodcastManager.Api.Definitions;

namespace PodcastManager.Api.Modules.Administration.Podcasts.FromPlaylists;

public class FromPlaylistsEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/admin/podcasts/publish/from-playlists", PublishFromPlaylists);
    }
    
    internal static void PublishFromPlaylists([FromServices] IEnqueuerAdapter enqueuer) =>
        enqueuer.EnqueuePublishPodcastFromPlaylists();

    public void DefineServices(IServiceCollection services)
    {
    }
}