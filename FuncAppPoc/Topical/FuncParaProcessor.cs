using FuncAppPoc.Domain.Model;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace FuncAppPoc.Topical
{
    public static class FuncParaProcessor
    {
        [FunctionName("FuncParaProcessor")]
        public static void Run([ServiceBusTrigger("hweb_poc_passage_published_topic", "hweb_sbus_subscription_passage_processor", Connection = "SASListener")]Message sbusMsg, ILogger log)
        {
            ParaMessage message = null;

            if (sbusMsg != null && sbusMsg.Body != null)
            {
                var messageBody = Encoding.UTF8.GetString(sbusMsg.Body);
                
                message = JsonConvert.DeserializeObject<ParaMessage>(messageBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                log.LogInformation($"C# ServiceBus topic trigger function processed message: {message.Title}");
            }           
        }
    }
}
