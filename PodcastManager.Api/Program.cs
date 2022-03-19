using PodcastManager.Api;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "iTunes Crawler")
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);

var app = builder
    .Configure()
    .Build();

app
    .SetUp();

app.Urls.Add("http://host.docker.internal:80");
app.Run();