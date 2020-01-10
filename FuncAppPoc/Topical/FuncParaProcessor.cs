using FuncAppPoc.Common;
using FuncAppPoc.Domain.Model;
using FuncAppPoc.ParagraphProcessor.Extensions;
using FuncAppPoc.ParagraphProcessor.Services;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;

namespace FuncAppPoc.Topical
{
    public static class FuncParaProcessor
    {
        /// <summary>
        /// Set Analyser Artificially from Unit Tests
        /// </summary>
        public static IParagraphAnalyser Analyser { get; set; }

        /// <summary>
        /// Static Constructor - Initialises any Mapper
        /// </summary>
        static FuncParaProcessor()
        {
            //MapInitializer.Activate();
        }

        [FunctionName("FuncParaProcessor")]
        public static void Run([ServiceBusTrigger("hweb_poc_passage_published_topic2", "hweb_sbus_subscription_passage_processor", Connection = "SASListener")]Message sbusMsg, ILogger log)
        {
            try
            {
                ServiceInitializer.Initialize();

                ParaMessage message = null;

                if (sbusMsg != null && sbusMsg.Body != null)
                {
                    var messageBody = Encoding.UTF8.GetString(sbusMsg.Body);

                    message = JsonConvert.DeserializeObject<ParaMessage>(messageBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    log.LogInformation($"C# ServiceBus topic trigger function processed message: {message.Title}");
                }

                if (message != null)
                {
                    var analyser = GetAnalyser();

                    var result = analyser.Analyse(message.Sample);

                    if (result != null)
                    {
                        log.LogInformation($"Longest Sentence is: {result.LongestSentence} having {result.MaxWordCount} words!");
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogCritical(ex, $"FAILED to process message! : {ex.Message} - {ex.StackTrace}");
            }                       
        }

        private static IParagraphAnalyser GetAnalyser()
        {
            if (Analyser == null)
            {
                // (uses extension method provided in Analyser Component)               
                ServiceInitializer.Services.RegisterAnalyserServices("Test");

                // Build Service Provider
                var serviceProvider = ServiceInitializer.Services.BuildServiceProvider();

                // Get Calculator Factory
                Analyser = serviceProvider.GetService<IParagraphAnalyser>();                
                // Analyser = new ParagraphAnalyser(ServiceInitializer.LoggerFactory.CreateLogger<ParagraphAnalyser>());
            }

            return Analyser;
        }
    }
}