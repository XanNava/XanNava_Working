using Grace.Extensions.Hosting;
using PlayGroundLibrary.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayGround;
using Serilog;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var service = scope.ServiceProvider;

try
{
    service.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IMessages, Messages>();
            services.AddSingleton<App>();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        });
}