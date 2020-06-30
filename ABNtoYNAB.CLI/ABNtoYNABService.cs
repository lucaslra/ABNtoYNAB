using System.Threading;
using System.Threading.Tasks;
using ABNtoYNAB.BL;
using Microsoft.Extensions.Hosting;

namespace ABNtoYNAB
{
    internal class ABNtoYNABService : IHostedService
    {
        private readonly CLIOptions options;

        public ABNtoYNABService(CLIOptions options) => this.options = options;

        public async Task StartAsync(CancellationToken cancellationToken)
            => await new TabFileConverter(options.FilePath).ExportAsYNAB();

        public Task StopAsync(CancellationToken cancellationToken) 
            => throw new System.NotImplementedException();
    }
}
