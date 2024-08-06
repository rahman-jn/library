using Entities;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _repoContext;
    private IUserRepository _user;
    private IRoleRepository _role;

    public RepositoryWrapper(RepositoryContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public IUserRepository User
    {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(_repoContext);
            }

            return _user;
        }
    }

    public IRoleRepository Role
    {
        get
        {
            if (_role == null)
            {
                _role = new RoleRepository(_repoContext);
            }

            return _role;
        }
    }
}