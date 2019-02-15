using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoLoja.Domain
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public Category(){}

        public Category(string name)
        {
            //validate fields
            SetName(name);
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
