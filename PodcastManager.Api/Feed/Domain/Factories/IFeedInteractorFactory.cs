using PodcastManager.Api.Feed.Domain.Interactors;

namespace PodcastManager.Api.Feed.Domain.Factories;

public interface IFeedInteractorFactory
{
    IPlaylistInteractor CreatePlaylist();
}