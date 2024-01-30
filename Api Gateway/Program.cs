
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.Middleware;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("ocelot.json"); // Ajoutez le fichier de configuration Ocelot
                });

                webBuilder.ConfigureServices(services =>
                {
                    // Ajoutez les services nécessaires
                });

                webBuilder.Configure(app =>
                {
                //    // Ajoutez Ocelot middleware
                  app.UseOcelot().Wait();
                });
            });
}
