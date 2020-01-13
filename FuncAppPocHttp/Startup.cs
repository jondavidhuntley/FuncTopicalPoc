using FuncAppPoc.ParagraphProcessor.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FuncAppPocHttp.Startup))]
namespace FuncAppPocHttp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddHttpClient();

            //builder.Services.AddSingleton((s) => {
            //    return new MyService();
            //});

            //builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();

            builder.Services.AddSingleton<IParagraphAnalyser, ParagraphAnalyser>();
        }
    }
}