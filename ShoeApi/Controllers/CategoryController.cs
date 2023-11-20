// CategoryController.cs

using Microsoft.AspNetCore.Mvc;
using ShoeApi.Entities;
using ShoeApi.Models;
using ShoeApi.Services;

namespace ShoeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            var newCategory = _categoryService.AddCategory(categoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
        }

        [HttpPut("{id}")]
        public ActionResult<Category> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            var updatedCategory = _categoryService.UpdateCategory(id, categoryDTO);

            if (updatedCategory == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            var deletedCategory = _categoryService.DeleteCategory(id);

            if (deletedCategory == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(deletedCategory);
        }
    }
}
