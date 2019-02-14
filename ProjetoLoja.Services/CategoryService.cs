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

        public void Add(CategoryDTO categoryDTO)
        {
            var category = _categoryRepository.GetById(categoryDTO.Id);
            if (category == null)
            {
                category = new Category(categoryDTO.Name);
                _categoryRepository.Insert(category);
            }
            //else
            //update category
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public bool Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category!= null)
                return _categoryRepository.Delete(category);
            return false;
        }
    }
}