using PodcastManager.Api.Feed.Domain.Repositories;

namespace PodcastManager.Api.Feed.Domain.Factories;

public interface IFeedRepositoryFactory
{
    IPlaylistRepository CreatePlaylist();
}