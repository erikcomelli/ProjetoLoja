using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLoja.Domain.DTO
{
    public class ProductDTO : EntityDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string ImageBase64 { get; set; }
    }
}
