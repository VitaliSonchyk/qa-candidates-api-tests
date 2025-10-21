using Clients.QACandidatesClients;
using Core.Configuration;
using Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Serilog;
using Services.QACandidatesServices;
using Services.QACandidatesServices.Interfaces;
using Services.RequestHandlers;

namespace Tests
{
    public class ServiceProvider
    {
        public static IServiceCollection Register(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            services.AddSingleton(Log.Logger);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build()
                .Get<Config>();

            services.AddLogging(builder => builder.AddSerilog());
            services.AddSingleton(configuration);

            //Register clients
            services.AddQACandidateClient<IEnergyClient>(configuration.BaseUrl);
            services.AddQACandidateClient<IBuyClient>(configuration.BaseUrl);
            services.AddQACandidateClient<IOrdersClient>(configuration.BaseUrl);
            services.AddQACandidateClient<IResetClient>(configuration.BaseUrl);
            services.AddRefitClient<ILoginClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(configuration.BaseUrl);
                });

            //Register services
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IOrdersService, OrdersService>();
            services.AddSingleton<IResetService, ResetService>();
            services.AddSingleton<IBuyService, BuyService>();
            services.AddSingleton<IEnergyService, EnergyService>();

            //Register handlers
            services.AddTransient<AuthHandler>();

            return services;
        }

        public static IServiceProvider Build()
        {
            var services = Register(new ServiceCollection());
            return services.BuildServiceProvider();
        }
    }
}
