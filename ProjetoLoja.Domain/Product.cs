using System;

namespace ProjetoLoja.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
    }
}
