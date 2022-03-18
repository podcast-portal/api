using PodcastManager.Api.Feed.Domain.Models;
using PodcastManager.Api.Tests.Doubles;

namespace PodcastManager.Api.Tests.Feed.Doubles;

public class FeedSpy : FeedStub
{
    public SpyHelper<FeedInfo> BuildSpy { get; } = new();

    public override string Build(FeedInfo feed)
    {
        BuildSpy.Call(feed);
        return base.Build(feed);
    }
}