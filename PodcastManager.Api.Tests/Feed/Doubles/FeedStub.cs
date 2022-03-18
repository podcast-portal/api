using PodcastManager.Api.Feed.Adapters;

namespace PodcastManager.Api.Tests.Feed.Doubles;

public class FeedStub : IFeedAdapter
{
    public static string Rss => "<rss><channel><title>Sample RSS</title></channel></rss>";

    public virtual string Build(Api.Feed.Domain.Models.FeedInfo feed)
    {
        return Rss;
    }
}