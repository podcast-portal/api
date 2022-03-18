namespace PodcastManager.Api.Feed.Domain.Models;

public record FeedInfo(
    string Title,
    string? Link = null,
    string? Description = null,
    Image? Image = null)
{
    public Item[] Items { get; init; } = Array.Empty<Item>();
}

public record Image(string Url, string Title, string Link);