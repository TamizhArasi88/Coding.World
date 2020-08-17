using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.ServiceDiscovery
{
    public sealed class ProductRequest
    {
        public int ProductID { get; set; }
        public string SearchCriteria { get; set; }
        public string SearchText { get; set; }
    }
}
