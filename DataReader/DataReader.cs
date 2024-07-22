using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DataReader
{
    public class DataReader(ILogger<DataReader> logger)
    {
        [Function(nameof(DataReader))]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            logger.LogInformation($"{nameof(DataReader)} received request.");

            return new OkObjectResult("data");
        }
    }
}
