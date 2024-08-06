using Entities;

namespace libraryapi.Controllers;

public class AuthController
{
    private  RepositoryContext _repositoryContext;

    public AuthController(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
}