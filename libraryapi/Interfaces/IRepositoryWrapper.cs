namespace libraryapi.Interfaces;

public interface IRepositoryWrapper
{
    IUserRepository User { get; }
    IRoleRepository Role { get; }
    IAuthRepositiry Auth { get; }
    void Save();
}