using AutoMapper;
using StoryShelfApi.Domain;
using StoryShelfApi.Models;

namespace StoryShelfApi.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookResponse>();

            
        }
    }
}
