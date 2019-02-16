using ProjetoLoja.Domain;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoLoja.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool Add(CategoryDTO categoryDTO)
        {
            var category = _categoryRepository.GetById(categoryDTO.Id ?? 0);
            if (category == null)
                category = new Category(categoryDTO.Name);
            else
                category.SetName(categoryDTO.Name);

            return _categoryRepository.Insert(category);            
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public CategoryDTO GetById(int? id)
        {
            return ConvertCategoryToCategoryDTO(_categoryRepository.GetById(id.Value));
        }

        public bool Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category!= null)
                return _categoryRepository.Delete(category);
            return false;
        }

        private CategoryDTO ConvertCategoryToCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}