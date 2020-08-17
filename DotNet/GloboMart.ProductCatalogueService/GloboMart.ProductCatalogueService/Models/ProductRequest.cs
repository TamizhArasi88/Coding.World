using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboMart.ProductCatalogueService
{
    public class ProductRequest
    {
        public int ProductID { get; set; }
        public string SearchText { get; set; }
        public string SearchCriteria { get; set; }
    }
}