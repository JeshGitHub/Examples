using LogService;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration
            .ReadFrom.Configuration(hostingContext.Configuration)
            .Enrich.FromLogContext();
    })
    .ConfigureServices(services =>
	{
		services.AddHostedService<Worker>();
	})
	.Build();

await host.RunAsync();
