using ProjetoLoja.Domain.DTO;
using ProjetoLoja.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLoja.Domain.Storer
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(ProductDTO productDTO)
        {
            var category = _categoryRepository.GetById(productDTO.CategoryId);

            var product = _productRepository.GetById(productDTO.Id);
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
