﻿using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Domain;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Services;
using System;
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
            //var categories =_categoryService.GetAll().ToList();
            //var categoriesDto = new List<CategoryDTO>();
            //foreach (var item in categories)
            //{
            //    categoriesDto.Add(SetCategoryDTO(item));
            //}
            //return View(categoriesDto);
            return View();
        }

        public IActionResult CreateOrEdit()
        {
            
            return View();
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
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name == searchValue);
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

        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(new CategoryDTO { Name = dto.Name });
            }            
            return View();
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
            catch(Exception)
            {
                success = false;
            }
            if (!success)
                returnMessage = errorMessage;
            return Json(new { response = new ResponseDTO(success,returnMessage) });
        }                   
    }
}