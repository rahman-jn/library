using Entities;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public Category GetCategoryById(int categoryId)
    {
        var query = FindByCondition(
            cat => cat.Id.Equals(categoryId) && cat.Active.Equals(1),
            cat => new Category
            {
                Name = cat.Name,
            }
            ); 
            
        return query.FirstOrDefault();
    }
    
    public void CreateCategory(Category category)
    {
        Create(category);
    }
}