using AutoMapper;
using Readline.Service.DTOs.Books;
using Readline.Service.DTOs.Users;
using Readline.Service.DTOs.Genres;
using Readline.Domain.Entites.Books;
using Readline.Domain.Entites.Users;
using Readline.Service.DTOs.Categories;
using Readline.Domain.Entites.Categories;

namespace Readline.Service.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<User,UserRegisterDto>().ReverseMap();
        CreateMap<User,UserResultDto>().ReverseMap();
        CreateMap<User,UserUpdateDto>().ReverseMap();
        
        //Category
        CreateMap<Category,CategoryCreationDto>().ReverseMap();
        CreateMap<Category,CategoryUpdateDto>().ReverseMap();
        CreateMap<Category,CategoryResultDto>().ReverseMap();
        
        //Genre
        CreateMap<Genre,GenreCreationDto>().ReverseMap();
        CreateMap<Genre,GenreUpdateDto>().ReverseMap();
        CreateMap<Genre,GenreResultDto>().ReverseMap();

        //Book
        CreateMap<Book,BookCreationDto>().ReverseMap();
        CreateMap<Book,BookUpdateDto>().ReverseMap();
        CreateMap<Book,BookResultDto>().ReverseMap();
    }
}
