namespace PodcastManager.Api.Feed.Adapters;

public interface IFeedAdapter
{
    string Build(Domain.Models.FeedInfo feed);
}