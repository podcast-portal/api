namespace PodcastManager.Api.Feed.Domain.Repositories;

public interface IPlaylistRepository
{
    Task<Models.FeedInfo> GetFeed(string username, string slug);
}