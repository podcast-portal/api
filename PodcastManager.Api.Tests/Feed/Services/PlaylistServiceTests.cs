using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PodcastManager.Api.Feed.Application.Services;
using PodcastManager.Api.Feed.Domain.Interactors;
using PodcastManager.Api.Tests.Feed.Doubles;

namespace PodcastManager.Api.Tests.Feed.Services;

public class PlaylistServiceTests
{
    private IPlaylistInteractor service = null!;
    private PlaylistRepositorySpy repositorySpy = null!;
    private FeedSpy feedSpy = null!;

    private void CreateService()
    {
        repositorySpy = new PlaylistRepositorySpy();
        feedSpy = new FeedSpy();
        
        var newService = new PlaylistService();
        newService.SetRepository(repositorySpy);
        newService.SetFeed(feedSpy);
        service = newService;
    }

    [SetUp]
    public void SetUp() => CreateService();

    [Test]
    public void Constructor_ShouldBeInheritsFromPlaylistInteractor() =>
        service.Should().BeAssignableTo<IPlaylistInteractor>();

    [Test]
    public async Task FromPlaylist_ShouldCallGetFeedFromRepository()
    {
        const string username = "user1";
        const string slug = "playlist1";
        
        var rss = await service.FromPlaylist(username, slug);

        repositorySpy.GetFeedSpy.ShouldBeCalledOnce();
        repositorySpy.GetFeedSpy.LastParameter
            .Should().Be((username, slug));

        feedSpy.BuildSpy.ShouldBeCalledOnce();
        feedSpy.BuildSpy.LastParameter
            .Should().BeEquivalentTo(repositorySpy.Feed);

        rss.Should().Be(FeedStub.Rss);
    }
}