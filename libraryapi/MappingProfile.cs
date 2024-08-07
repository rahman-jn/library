using AutoMapper;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap< UserDtoForLogin, User>();
    }
}