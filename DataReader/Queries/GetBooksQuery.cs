using DataReader.Models;
using MediatR;

namespace DataReader.Queries;
public class GetBooksQuery : IRequest<List<Book>>
{
}
