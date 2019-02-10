using ProjetoLoja.Domain;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Interfaces;

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
    }
}