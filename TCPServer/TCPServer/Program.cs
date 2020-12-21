using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Sockets;

namespace TCPServer
{
    class Program
    {
        static void Main_jiwag(String[] _args)
        {
            
        }


        static void Main(String[] _args)
        {
            var hostBuilder = new HostBuilder()
                  .UseConsoleLifetime()
                  .ConfigureServices(service =>
                  {
                      service.AddHostedService<LocalHoster>();
                      service.AddLogging(c => { c.AddConsole(); });
                  })
                  .ConfigureLogging(logging =>
                  {
                      // logging.ClearProviders();
                      logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                  });


            using (var hoster = hostBuilder.Build())
            {
                hoster.Run();
            }

        }


        
    }
}