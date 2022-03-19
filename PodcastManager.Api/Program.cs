using PodcastManager.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .Configure()
    .Build();

app.SetUp();
 
app.Urls.Add(Configuration.ListenUrl);
app.Run();