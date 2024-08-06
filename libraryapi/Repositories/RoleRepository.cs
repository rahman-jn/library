using Entities;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class RoleRepository :  RepositoryBase<Role>, IRoleRepository
{
  public RoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  {

  }
}