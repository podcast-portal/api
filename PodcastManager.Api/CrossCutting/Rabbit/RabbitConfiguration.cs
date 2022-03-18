namespace PodcastManager.Api.CrossCutting.Rabbit;

public static class RabbitConfiguration
{
    public static readonly string Host =
        Environment.GetEnvironmentVariable("RabbitUrl")
        ?? "localhost";
    
    public static string PublishAllFromPlaylistQueue { get; } =
        Environment.GetEnvironmentVariable("PublishAllFromPlaylists")
        ?? "PodcastManager.PublishAllFromPlaylists";
    
    public static string ImportAllQueue { get; } =
        Environment.GetEnvironmentVariable("ImportAllQueue")
        ?? "PodcastManager.ImportAll";
}