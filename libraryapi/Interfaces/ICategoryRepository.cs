using libraryapi.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Interfaces;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    Category GetCategoryById(int categoryId);
    void CreateCategory(Category category);
}