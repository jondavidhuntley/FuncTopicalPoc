using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FuncAppPoc.Common
{
    public static class ServiceInitializer
    {
        private static ILoggerFactory _loggerFactory;       
        private static IConfiguration _configuration;

        /// <summary>
        /// Service Collection
        /// </summary>
        public static IServiceCollection Services { get; private set; }

        /// <summary>
        /// Logger Factory
        /// </summary>
        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_loggerFactory == null)
                {
                    _loggerFactory = new LoggerFactory();
                }

                return _loggerFactory;
            }
        }

        /// <summary>
        /// Initialize Service Collection
        /// </summary>
        public static void Initialize()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            _configuration = builder.Build();

            Services = new ServiceCollection();
            Services.AddLogging(); // only available in extension 2.20
        }

        /*
        public static ITokenService AirlineTokenHandler
        {
            get
            {
                if (_siAirlineTokenServiceInstance == null)
                {
                    var siTokenServiceUrl = Environment.GetEnvironmentVariable("SITokenServiceUrl");
                    var clientId = Environment.GetEnvironmentVariable("AirlineServiceClientId");
                    var clientSecret = Environment.GetEnvironmentVariable("AirlineServiceClientSecret");
                    var audience = Environment.GetEnvironmentVariable("AirlineServiceAudience");
                    var grantType = Environment.GetEnvironmentVariable("AirlineServiceGrantType");

                    _siAirlineTokenServiceInstance = new ClientCredentialsService(siTokenServiceUrl, clientId, clientSecret, audience, grantType, LoggerFactory.CreateLogger<ClientCredentialsService>());
                }

                return _siAirlineTokenServiceInstance;
            }
        }
        */
    }
}