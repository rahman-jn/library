using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IAuthRepositiry
{
    public UserDto GetUserAccount(User user);
}