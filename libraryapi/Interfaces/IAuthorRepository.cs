using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Interfaces;

public interface IAuthorRepository : IRepositoryBase<Author>
{
    AuthorDto GetAuthorById(int authorId);
    void CreateAuthor(Author author);
}