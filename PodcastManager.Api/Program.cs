using PodcastManager.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .Configure()
    .Build();

app.SetUp();

// app.Urls.Add("http://*:5000");
app.Urls.Add("http://*:5555");
app.Run();