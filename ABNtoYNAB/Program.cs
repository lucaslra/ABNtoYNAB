using System.IO;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ABNtoYNAB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Parser.Default
                .ParseArguments<CLIOptions>(args)
                .WithParsedAsync(async options =>
                {
                    await CreateHostBuilder(options).RunConsoleAsync();
                });
        }

        private static IHostBuilder CreateHostBuilder(CLIOptions options)
        {
            return new HostBuilder()
                .UseConsoleLifetime()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices(services =>
                {
                    services.AddSingleton(options);
                    services.AddHostedService<ABNtoYNABService>();
                });
        }
    }
}
