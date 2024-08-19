namespace libraryapi.Interfaces;

public interface IRepositoryWrapper
{
    IUserRepository User { get; }
    IRoleRepository Role { get; }
    IAuthRepositiry Auth { get; }
    ICategoryRepository Category { get; }
    IAuthorRepository Author { get; }
    void Save();
}
