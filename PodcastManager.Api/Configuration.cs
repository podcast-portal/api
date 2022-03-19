namespace PodcastManager.Api;

public static class Configuration
{
    public static readonly string ListenUrl =
        Environment.GetEnvironmentVariable("ListenUrl")
        ?? "http://localhost:5555/";
}