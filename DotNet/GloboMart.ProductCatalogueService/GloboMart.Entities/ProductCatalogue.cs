using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Entities
{
    public sealed class ProductCatalogue
    {
        public ProductCatalogue()
        {
            ID = 0;
            Name = string.Empty;
            ProductType = string.Empty;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
    }
}
