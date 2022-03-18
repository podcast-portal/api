using MongoDB.Driver;
using PodcastManager.Api.CrossCutting.Mongo;
using PodcastManager.Api.Feed.CrossCutting.Mongo;
using PodcastManager.Api.Feed.Domain.Factories;
using PodcastManager.Api.Feed.Domain.Repositories;

namespace PodcastManager.Api.Feed.CrossCutting.IoC;

public class FeedRepositoryFactory : IFeedRepositoryFactory
{
    public IPlaylistRepository CreatePlaylist()
    {
        var repository = new MongoPlaylistRepository();
        repository.SetDatabase(GetDatabase());
        return repository;
    }
    
    private static IMongoDatabase GetDatabase()
    {
        var client = new MongoClient(MongoConfiguration.MongoUrl);
        var database = client.GetDatabase(MongoConfiguration.MongoDatabase);
        return database;
    }
}