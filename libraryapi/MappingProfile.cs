using AutoMapper;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap< UserDtoForLogin, User>();
        CreateMap< UserDtoForCreation, User>();
        CreateMap<User, UserListDto>()
            .ForMember(dest => dest.ReservedBooksCount,
                opt => 
                    opt.MapFrom(src => src.UserBooks.Count(book => book.Status == 0)));
        CreateMap<Book, Book>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
            
    }
}