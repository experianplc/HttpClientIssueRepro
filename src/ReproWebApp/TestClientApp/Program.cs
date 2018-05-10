namespace TestClientApp
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel(c => c.AddServerHeader = false)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .ConfigureLogging((logging) =>
            {
                logging.AddConsole();
            })
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }
}
