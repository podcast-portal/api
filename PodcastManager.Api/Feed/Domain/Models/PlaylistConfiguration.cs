namespace PodcastManager.Api.Feed.Domain.Models;

public record PlaylistConfiguration(
    string? Name,
    int? EpisodeCount,
    DateOnly? StartDate,
    SkipTime? Skip);