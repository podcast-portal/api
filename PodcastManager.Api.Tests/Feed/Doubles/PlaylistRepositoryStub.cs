using System.Threading.Tasks;
using PodcastManager.Api.Feed.Domain.Models;
using PodcastManager.Api.Feed.Domain.Repositories;

namespace PodcastManager.Api.Tests.Feed.Doubles;

public class PlaylistRepositoryStub : IPlaylistRepository
{
    public FeedInfo Feed { get; } = new("Test Feed 1");

    public virtual Task<FeedInfo> GetFeed(string username, string slug)
    {
        return Task.FromResult(Feed);
    }
}