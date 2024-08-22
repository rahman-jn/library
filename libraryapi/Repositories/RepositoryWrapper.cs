using Entities;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _repoContext;
    private IUserRepository _user;
    private IRoleRepository _role;
    private IAuthRepositiry _auth;
    public ICategoryRepository _category;
    public IAuthorRepository _author;
    public IBookRepository _book;

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
    
    public IAuthRepositiry Auth
    {
        get
        {
            if (_auth == null)
            {
                _auth = new AuthRepository(_repoContext);
            }
            return _auth;
        }
    }
    
    public IAuthorRepository Author
    {
        get
        {
            if (_author == null)
            {
                _author = new AuthorRepository(_repoContext);
            }

            return _author;
        }
    }
    
    public ICategoryRepository Category
    {
        get
        {
            if (_category == null)
            {
                _category = new CategoryRepository(_repoContext);
            }

            return _category;
        }
    }
    
    public IBookRepository Book
    {
        get
        {
            if (_book == null)
            {
                _book = new BookRepository(_repoContext);
            }

            return _book;
        }
    }

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}