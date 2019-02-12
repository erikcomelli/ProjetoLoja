using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Domain;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLoja.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories =_categoryService.GetAll().ToList();
            var categoriesDto = new List<CategoryDTO>();
            foreach (var item in categories)
            {
                categoriesDto.Add(SetCategoryDTO(item));
            }
            return View(categoriesDto);
        }

        public IActionResult CreateOrEdit()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(new CategoryDTO { Name = dto.Name });
            }            
            return View();
        }

        private CategoryDTO SetCategoryDTO(Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}