using ProjetoLoja.Domain;
using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Interfaces;

namespace ProjetoLoja.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Add(ProductDTO productDTO)
        {
            var category = _categoryRepository.GetById(productDTO.CategoryId);

            var product = _productRepository.GetById(productDTO.Id.Value);
            if (product == null)
            {
                product = new Product(productDTO.Name, productDTO.Quantity, productDTO.Description, productDTO.Category, productDTO.Price);
                _productRepository.Insert(product);
            }
            //else
            //update
        }
    }
}