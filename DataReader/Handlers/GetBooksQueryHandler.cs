using AutoMapper;
using DataReader.Models;
using DataReader.Models.Database;
using DataReader.Queries;
using MediatR;
using Microsoft.Azure.Cosmos;
using CosmosContainer = Microsoft.Azure.Cosmos.Container;

namespace DataReader.Handlers;
public class GetBooksQueryHandler(CosmosClient cosmosClient, IMapper mapper)
    : IRequestHandler<GetBooksQuery, List<Book>>
{
    private readonly CosmosContainer _container = cosmosClient.GetContainer("BookstoreDatabase", "BooksContainer");

    public async Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var query = new QueryDefinition("SELECT * FROM c");

        var iterator = _container.GetItemQueryIterator<BookEntity>(query);
        var results = new List<BookEntity>();

        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync(cancellationToken);
            results.AddRange(response.ToList());
        }

        return mapper.Map<List<Book>>(results);
    }
}