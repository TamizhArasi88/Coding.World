using GloboMart.Entities;
using GloboMart.ServiceDiscovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GloboMartDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Globo Mart";
            ProductCatalogueViewModel viewModel = new ProductCatalogueViewModel();
            viewModel.Products = ServiceDiscoverer.SearchResults("", "");
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult AddProduct()
        {
            ProductCatalogue prodObj = new ProductCatalogue();
            return View("AddProduct", prodObj);
        }

        [HttpPost]
        public ActionResult SaveProduct(ProductCatalogue productModel)
        {
            if (productModel != null)
                ServiceDiscoverer.AddProduct(productModel);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveProduct(int id)
        {
            if (id > 0)
                ServiceDiscoverer.RemoveProduct(new ProductCatalogue { ID = id });
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            List<ProductCatalogue> listProds = new List<ProductCatalogue>();
            listProds = ServiceDiscoverer.SearchResults("", "");
            return View("Index", listProds);
        }
    }
}