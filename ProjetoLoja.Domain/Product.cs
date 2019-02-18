using System;

namespace ProjetoLoja.Domain
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public double Price { get; private set; }
        public string ImageBase64 { get; private set; }

        public Product(string name, int quantity, string description, Category category, double price, string imageBase64)
        {            
            SetProduct(name, quantity, description, category, price, imageBase64);
        }

        private void SetProduct(string name, int quantity, string description, Category category, double price, string imageBase64)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
            Category = category;
            Price = price;
            ImageBase64 = imageBase64;
        }
    }
}
