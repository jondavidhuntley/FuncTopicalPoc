using FuncAppPoc.Domain.Model;
using FuncAppPoc.ParagraphProcessor.Services;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;

namespace FuncAppPocDI.Topical
{
    /// <summary>
    /// .Net Core 3.0 !!!
    /// </summary>
    public class FuncParagraphReader
    {
        private readonly IParagraphAnalyser _analyser;

        public FuncParagraphReader(IParagraphAnalyser analyser)
        {
            _analyser = analyser;
        }

        [FunctionName("FuncParagraphReader")]
        public void Run([ServiceBusTrigger("hweb_poc_passage_published_topic", "hweb_sbus_subscription_passage_processor", Connection = "SASListener")]Message sbusMsg, ILogger log)
        {
            try
            {               
                ParaMessage message = null;

                if (sbusMsg != null && sbusMsg.Body != null)
                {
                    var messageBody = Encoding.UTF8.GetString(sbusMsg.Body);

                    message = JsonConvert.DeserializeObject<ParaMessage>(messageBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    log.LogInformation($"C# ServiceBus topic trigger function processed message: {message.Title}");
                }

                if (message != null)
                {                   
                    var result = _analyser.Analyse(message.Sample);

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
    }
}