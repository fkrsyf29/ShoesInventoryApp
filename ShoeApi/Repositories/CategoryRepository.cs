using Microsoft.EntityFrameworkCore;
using ShoeApi.Data;
using ShoeApi.Entities;
using ShoeApi.Models;

namespace ShoeApi.Repositories;
public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category GetCategoryById(int id);
    Category AddCategory(Category category);
    Category UpdateCategory(Category category);
    Category DeleteCategory(int id);
}
public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategoryById(int id)
    {
        return _context.Categories.FirstOrDefault(c => c.Id == id);
    }

    public Category AddCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    public Category UpdateCategory(Category category)
    {
        category.Updated = DateTime.Now;
        _context.Categories.Update(category);
        _context.SaveChanges();
        return category;
    }

    public Category DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category != null)
        {
            category.Updated = DateTime.Now;
            category.IsDeleted = true;
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        return category;
    }
}