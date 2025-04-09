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
            CreateMap<Book, BookResponse>().ForMember(dest=>dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name));

            CreateMap<GenreRequest, Genre>();
            CreateMap<Genre, GenreResponse>();

            
        }
    }
}
