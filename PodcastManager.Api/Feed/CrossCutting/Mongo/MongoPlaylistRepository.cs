using MongoDB.Driver;
using PodcastManager.Api.Feed.CrossCutting.Mongo.Aggregations;
using PodcastManager.Api.Feed.Domain.Models;
using PodcastManager.Api.Feed.Domain.Repositories;

namespace PodcastManager.Api.Feed.CrossCutting.Mongo;

public class MongoPlaylistRepository : IPlaylistRepository
{
    private IMongoDatabase database = null!;

    public async Task<Domain.Models.FeedInfo> GetFeed(string username, string slug)
    {
        var collection = database.GetCollection<Playlist>("playlists");
        var pipeline = PipelineDefinition<Playlist, Item>
            .Create(AggregationFactory.Instance.GetSinglePlaylistFeed(username, slug, 500));
        var cursor = await collection.AggregateAsync(pipeline);

        var feed = new Domain.Models.FeedInfo($"Feed {slug}")
        {
            Items = (await cursor.ToListAsync()).ToArray()
        };
        
        return feed;
    }

    public void SetDatabase(IMongoDatabase database) =>
        this.database = database;
}