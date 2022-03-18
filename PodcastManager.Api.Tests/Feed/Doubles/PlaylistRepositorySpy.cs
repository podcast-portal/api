using System.Threading.Tasks;
using PodcastManager.Api.Feed.Domain.Models;
using PodcastManager.Api.Tests.Doubles;

namespace PodcastManager.Api.Tests.Feed.Doubles;

public class PlaylistRepositorySpy : PlaylistRepositoryStub
{
    public SpyHelper<(string, string)> GetFeedSpy { get; } = new();

    public override Task<FeedInfo> GetFeed(string username, string slug)
    {
        GetFeedSpy.Call((username, slug));
        return base.GetFeed(username, slug);
    }
}