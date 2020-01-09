using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncAppPoc.Topical
{
    public static class FuncParagraphProcessor
    {
        [FunctionName("FuncParagraphProcessor")]
        public static void Run([ServiceBusTrigger("hweb_poc_passage_published_topic", "hweb_sbus_subscription_passage_processor2", Connection = "SASListener")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}