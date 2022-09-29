using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerConsumoAPIContagem.Resilience;

namespace WorkerConsumoAPIContagem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                //var connectionString = hostContext.Configuration.GetSection("UrlApiContagem").Value;
                services.AddSingleton(CircuitBreaker.CreatePolicy());
                services.AddHostedService<Worker>();
            });

            hostBuilder.Build().Run();
        }


}
}






