using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Services;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ProjetoLoja.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index() => View();

        public IActionResult CreateOrEdit(int id)
        {
            if (id > 0)
            {
                var category = _categoryService.GetById(id);
                return View(category);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDTO dto)
        {
            bool success = true;
            if (ModelState.IsValid)
                success = _categoryService.Add(dto);
            if (success)
            {
                TempData["Response"] = JsonConvert.SerializeObject(new ResponseDTO(success, "operação realizada com sucesso"));
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Response"] = JsonConvert.SerializeObject(new ResponseDTO(success, "erro na operação"));
                return View();
            }

        }

        public IActionResult DeleteCategory(int categoryId)
        {
            var returnMessage = "registro excluído";
            var errorMessage = "erro ao excluir";
            bool success = true;
            try
            {
                success = _categoryService.Delete(categoryId);
            }
            catch (Exception)
            {
                success = false;
            }
            if (!success)
                returnMessage = errorMessage;
            return Json(new { response = new ResponseDTO(success, returnMessage) });
        }
        public IActionResult GetAllCategories()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Skip number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction (asc, desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10, 20, 50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;

                int skip = start != null ? Convert.ToInt32(start) : 0;

                int recordsTotal = 0;

                // getting all Customer data  
                var customerData = _categoryService.GetAll();
                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name.Contains(searchValue.Trim()));
                }

                //total number of rows counts   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}