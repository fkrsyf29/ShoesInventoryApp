using ShoeApi.Entities;
using ShoeApi.Models;
using ShoeApi.Repositories;

namespace ShoeApi.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category AddCategory(CategoryDTO categoryDTO);
        Category UpdateCategory(int id, CategoryDTO categoryDTO);
        Category DeleteCategory(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public Category AddCategory(CategoryDTO categoryDTO)
        {
            var newCategory = new Category
            {
                Name = categoryDTO.CategoryName
            };

            return _categoryRepository.AddCategory(newCategory);
        }

        public Category UpdateCategory(int id, CategoryDTO categoryDTO)
        {
            var existingCategory = _categoryRepository.GetCategoryById(id);

            if (existingCategory == null)
            {
                // Handle not found scenario
                return null;
            }

            existingCategory.Name = categoryDTO.CategoryName;
            return _categoryRepository.UpdateCategory(existingCategory);
        }

        public Category DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }
    }
}