using AutoMapper;
using KonyvtarNyilvantartas.DTOs;
using KonyvtarNyilvantartas.Models;

namespace KonyvtarNyilvantartas.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookReadDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<BookCreateDTO, Book>();


            CreateMap<Author, AuthorReadDTO>();
            CreateMap<AuthorCreateDTO, Author>();
        }
    }
}
