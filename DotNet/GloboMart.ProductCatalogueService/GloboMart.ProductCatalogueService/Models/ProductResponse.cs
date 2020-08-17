using GloboMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboMart.ProductCatalogueService
{
    public class ProductResponse
    {
        public ProductResponse()
        {
            Products = new List<ProductCatalogue>();
        }
        public List<ProductCatalogue> Products { get; set; }
    }
}