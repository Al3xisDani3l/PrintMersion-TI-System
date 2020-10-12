using System;
using System.Collections.Generic;

namespace Scaffolding.Data
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
