using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using PodcastManager.Api.Feed.Adapters;
using PodcastManager.Api.Feed.Application.Adapters;
using PodcastManager.Api.Feed.Domain.Models;

namespace PodcastManager.Api.Tests.Feed.Adapters;

public class FeedAdapterTests
{
    private IFeedAdapter adapter = null!;

    private void CreateAdapter() => adapter = new FeedAdapter();

    [SetUp]
    public void SetUp() => CreateAdapter();

    [Test]
    public void Constructor_ShouldInheritsFromFeedAdapterInterface() =>
        adapter.Should().BeAssignableTo<IFeedAdapter>();

    [Test]
    public void Build_WithSimpleFeedReturnsSimpleRss()
    {
        var rss = File.ReadAllText(@"./Feed/SampleFeeds/SimpleRss.xml");
        var feed = new FeedInfo("Sample Feed 1");

        var result = adapter.Build(feed);
        
        result.Should().Be(rss);
    }

    [Test]
    public void Build_WithSimpleFeedReturnsFullHeadRss()
    {
        var rss = File.ReadAllText(@"./Feed/SampleFeeds/FullHeaderRss.xml");
        var feed = new FeedInfo(
            "Sample Feed 2",
            "https://podcastmanager.com",
            "this is a sample of description",
            new Image(
                "sampleimage.jpg",
                "Podcast Manager",
                "https://podcastmanager.com"));

        var result = adapter.Build(feed);
        
        result.Should().Be(rss);
    }

    [Test]
    public void Build_WithSimpleEpisodesRss()
    {
        var rss = File.ReadAllText(@"./Feed/SampleFeeds/SimpleEpisodesRss.xml");
        var feed = new FeedInfo(
            "Sample Feed 3",
            Image: new Image("sampleimage.jpg", "Podcast Manager", "https://podcastmanager.com"))
        {
            Items = new[]
            {
                new Item(
                    "episode 03",
                    new DateTime(2022, 3, 14, 13, 0, 0),
                    "sampleguid3",
                    new Enclosure("episode-03.mp3", 125, "audio/mpeg"), 
                    1,
                    Image: "image2"),
                new Item(
                    "episode 02",
                    new DateTime(2022, 3, 7, 13, 0, 0),
                    "sampleguid2",
                    new Enclosure("episode-02.mp3", 124, "audio/mpeg"), 
                    1),
                new Item(
                    "episode 01",
                    new DateTime(2022, 2, 28, 13, 0, 0),
                    "sampleguid1",
                    new Enclosure("episode-01.mp3", 123, "audio/mpeg"), 
                    1)
            }
        };

        var result = adapter.Build(feed);
        
        result.Should().Be(rss);
    }
}