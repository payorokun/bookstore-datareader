using AutoMapper;
using DataReader.Models;
using DataReader.Models.Database;

namespace DataReader.Profiles;
public class BookEntityMappingProfile : Profile
{
    public BookEntityMappingProfile()
    {
        CreateMap<BookEntity, Book>();
    }
}
