using PodcastManager.Api.Feed.Adapters;
using PodcastManager.Api.Feed.Domain.Interactors;
using PodcastManager.Api.Feed.Domain.Repositories;

namespace PodcastManager.Api.Feed.Application.Services;

public class PlaylistService : IPlaylistInteractor
{
    private IPlaylistRepository repository = null!;
    private IFeedAdapter feed = null!;

    public async Task<string> FromPlaylist(string username, string slug)
    {
        var feedModel = await repository.GetFeed(username, slug);
        return feed.Build(feedModel);
    }

    public void SetRepository(IPlaylistRepository repository) => this.repository = repository;
    public void SetFeed(IFeedAdapter feed) => this.feed = feed;
}