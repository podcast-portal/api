namespace PodcastManager.Api.Feed.Domain.Models;

public record Enclosure(string url, int length, string type);