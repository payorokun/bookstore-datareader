using DataReader.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace DataReader.Functions;

public class BooksReader(ILogger<BooksReader> logger, IMediator mediator)
{
    [Function(nameof(BooksReader))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        logger.LogInformation($"{nameof(BooksReader)} received request.");
        var books = await mediator.Send(new GetBooksQuery());
        return new OkObjectResult(books);
    }
}