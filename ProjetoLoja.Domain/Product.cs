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

        public Product(string name, int quantity, string description, Category category, double price)
        {
            //validate fields
            SetProduct(name, quantity, description, category, price);
        }

        private void SetProduct(string name, int quantity, string description, Category category, double price)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
            Category = category;
            Price = price;
        }
    }
}
