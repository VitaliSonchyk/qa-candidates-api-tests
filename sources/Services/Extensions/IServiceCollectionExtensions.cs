using Core.Common.Refit;
using Core.Converters;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Services.RequestHandlers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddQACandidateClient<TClient>(this IServiceCollection serviceCollection, string baseUrl) where TClient : class, IRefitClient
        {
            var jsonOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new Rfc1123DateTimeConverter() }
            };

            var refitSettings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
            };

            serviceCollection.AddRefitClient<TClient>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl))
                    .AddHttpMessageHandler<AuthHandler>();
        }
    }
}
