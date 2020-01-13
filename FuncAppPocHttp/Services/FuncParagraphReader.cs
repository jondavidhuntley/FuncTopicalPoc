using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FuncAppPoc.Domain.Model;
using FuncAppPoc.ParagraphProcessor.Services;

namespace FuncAppPocHttp
{
    public class FuncParagraphReader
    {
        private readonly IParagraphAnalyser _analyser;

        public FuncParagraphReader(IParagraphAnalyser analyser)
        {
            _analyser = analyser;
        }

        [FunctionName("FuncParagraphReader")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "FuncParagraphReader/{version}/")] 
            HttpRequest req, 
            string version,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");            

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var message = JsonConvert.DeserializeObject<ParaMessage>(requestBody, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            var response = string.Empty;

            if (message != null)
            {
                var result = _analyser.Analyse(message.Sample);

                response = $"Max word count is {result.MaxWordCount}";
            }

            return (ActionResult)new OkObjectResult($"Hello, {response}");
        }
    }
}
