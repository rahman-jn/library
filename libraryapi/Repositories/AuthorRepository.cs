using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public AuthorDto GetAuthorById(int authorId)
    {
        var query = FindByCondition(
            author => author.Id.Equals(authorId) && author.Active.Equals(1),
            author => new AuthorDto
            {
                FullName = author.FirstName + " " + author.LastName
            }
            ); 
            
        return query.FirstOrDefault();
    }
    
    public void CreateAuthor(Author author)
    {
        Create(author);
    }
}