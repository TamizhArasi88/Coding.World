using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.Entities
{
    public sealed class ProductPricing
    {
        public ProductPricing()
        {
            ProductID = 0;
            Price = 0;
        }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
    }
}
