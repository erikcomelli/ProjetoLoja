using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Services;

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
            return View();
        }

        public IActionResult CreateOrEdit()
        {
            _categoryService.Add(new CategoryDTO { Name = "categoryTest" });
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDTO dto)
        {
            return View();
        }
    }
}