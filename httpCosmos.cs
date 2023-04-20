using System.Net;
using System.Text.Json.Nodes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace isolatedNet7CosmosInput
{
    public class httpCosmos
    {
        private readonly ILogger _logger;

        public httpCosmos(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<httpCosmos>();
        }

        [Function("httpCosmos")]
        public IEnumerable<object> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        [CosmosDBInput("cosmosdb", "cosmoscollection",
            ConnectionStringSetting = "cosmosconnstring",
            SqlQuery = "SELECT VALUE COUNT(1) FROM c")] IEnumerable<object> orgCount)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            //var response = req.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            //response.WriteString("Welcome to Azure Functions!");

            return new List<string>();
        }
    }
}
