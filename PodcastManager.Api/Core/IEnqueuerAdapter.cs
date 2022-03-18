namespace PodcastManager.Api;

public interface IEnqueuerAdapter
{
    void EnqueuePublishPodcastFromPlaylists();
    void EnqueueStartCrawl();
}