using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Interfaces;

namespace ProjetoLoja.Domain.Storer
{
    public class CategoryStorer
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryStorer(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Store(CategoryDTO categoryDTO)
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
