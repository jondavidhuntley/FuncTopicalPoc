using FuncAppPoc.ParagraphProcessor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FuncAppPoc.ParagraphProcessor.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection RegisterAnalyserServices(
                this IServiceCollection services,
               string testParam)
        {           

            //services.AddSingleton<IParagraphAnalyser>((svc) =>
            //{
            //    var logger = svc.GetService<ILogger<ParagraphAnalyser>>();

            //    return new ParagraphAnalyser(logger);
            //});

            services.AddSingleton<IParagraphAnalyser, ParagraphAnalyser>();

            return services;
        }
    }
}