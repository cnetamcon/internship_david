using Microsoft.Extensions.Hosting;

namespace Host.Console
{
    public class WindowsBackgroundService : BackgroundService
    {
        private readonly Application _application;

        public WindowsBackgroundService(Application application)
        {
            _application = application;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _application.Start();
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _application.Stop();

            await Task.Delay(1500);

            await base.StopAsync(cancellationToken);
        }
    }
}
