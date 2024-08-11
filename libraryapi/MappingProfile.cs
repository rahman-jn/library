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
    }
}