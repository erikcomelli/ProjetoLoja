using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLoja.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            //validate fields
            SetCategory(name);
        }

        private void SetCategory(string name)
        {
            Name = name;
        }
    }
}
