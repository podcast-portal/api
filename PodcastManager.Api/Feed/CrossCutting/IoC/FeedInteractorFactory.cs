using PodcastManager.Api.Feed.Application.Adapters;
using PodcastManager.Api.Feed.Application.Services;
using PodcastManager.Api.Feed.Domain.Factories;
using PodcastManager.Api.Feed.Domain.Interactors;

namespace PodcastManager.Api.Feed.CrossCutting.IoC;

public class FeedInteractorFactory : IFeedInteractorFactory
{
    private IFeedRepositoryFactory repositoryFactory = null!;

    public IPlaylistInteractor CreatePlaylist()
    {
        var service = new PlaylistService();
        service.SetFeed(new FeedAdapter());
        service.SetRepository(repositoryFactory.CreatePlaylist());
        return service;
    }

    public void SetRepositoryFactory(IFeedRepositoryFactory repositoryFactory) =>
        this.repositoryFactory = repositoryFactory;
}