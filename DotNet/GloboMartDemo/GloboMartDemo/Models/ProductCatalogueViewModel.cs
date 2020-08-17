using GloboMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboMartDemo
{
    public class ProductCatalogueViewModel
    {
        public ProductCatalogueViewModel()
        {
            Products = new List<ProductCatalogue>();
            SearchCriteria = string.Empty;
            SearchText = string.Empty;
        }
        public List<ProductCatalogue> Products { get; set; }
        public string SearchCriteria { get; set; }
        public string SearchText { get; set; }
    }
}