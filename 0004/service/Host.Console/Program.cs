using Core.Logs;
using Core.Managers;
using Host.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Host.Console
{
    internal class Program
    {
        private static readonly ConsoleMessagePrinter _messagePrinter = new ConsoleMessagePrinter();

        public static void Main(string[] args)
        {
            try
            {
                Log.UI.OnNewMessage += Main_OnNewMessage;

                var host = CreateHostBuilder(args).Build();

                var application = host.Services.GetRequiredService<Application>();

                application.Start().Wait();
                application.Stop().Wait();

            }
            catch (Exception er)
            {
                Log.Current.Error(er);
            }
            finally
            {
                Thread.Sleep(1000);
            }
        }

        private static void Main_OnNewMessage(ItemMessage obj)
        {
            _messagePrinter.Print(obj.Message, obj.Type);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
             {
                 //services.AddHostedService<WindowsBackgroundService>();

                 DIRegistration di = new DIRegistration();
                 di.RegisterAll(ref services);
             });
    }
}