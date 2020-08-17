using GloboMart.Entities;
using GloboMart.ServiceDiscovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GloboMartDemo
{
    public class PricingController : Controller
    {
        // GET: Pricing
        public ActionResult Index()
        {
            return View(new ProductPricing());
        }

        [HttpPost]
        public ActionResult PriceDetails(ProductPricing product)
        {
            ProductPricing resProduct = new ProductPricing();
            resProduct = ServiceDiscoverer.GetProductPricing(product);
            return View("Index", resProduct);
        }
    }
}