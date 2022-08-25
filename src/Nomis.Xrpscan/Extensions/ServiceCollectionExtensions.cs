using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.Utils.Extensions;
using Nomis.Xrpscan.Interfaces;
using Nomis.Xrpscan.Interfaces.Settings;

namespace Nomis.Xrpscan.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Xrpscan service.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddXrpscanService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSettings<XrpscanSettings>(configuration);

            return services
                .AddTransient<IXrpscanClient, XrpscanClient>()
                .AddTransientInfrastructureService<IXrpscanService, XrpscanService>();
        }
    }
}