using GloboMart.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.ServiceDiscovery
{
    public sealed class ServiceDiscoverer
    {
        private static string ProductCatalogueAdd => ConfigurationManager.AppSettings["ProductCatalogue_Add"];
        private static string ProductCatalogueRemove => ConfigurationManager.AppSettings["ProductCatalogue_Remove"];
        private static string ProductCatalogueSearch => ConfigurationManager.AppSettings["ProductCatalogue_Search"];
        private static string ProductPricingGet => ConfigurationManager.AppSettings["ProductPricing_Get"];

        public static List<ProductCatalogue> SearchResults(string criteria, string searchText)
        {
            string inputJson = JsonConvert.SerializeObject(new ProductRequest
            { ProductID = 0, SearchCriteria = criteria, SearchText = searchText });
            List<ProductCatalogue> products = new List<ProductCatalogue>();

            HttpResponseMessage response = new HttpResponseMessage();
            //Task.Run(async () =>
            //{
            response = ConnectToProductServices(ProductCatalogueSearch, inputJson);
            var result = response.Content.ReadAsStringAsync().Result;
            ProductSearchResults searchResult = new ProductSearchResults();
            searchResult = JsonConvert.DeserializeObject<ProductSearchResults>(result);            
            //});
            return searchResult.Products;
        }

        public static void AddProduct(ProductCatalogue product)
        {
            //Task.Run(async () =>
            //{ return
            ConnectToProductServices(ProductCatalogueAdd, JsonConvert.SerializeObject(product));
            //});
        }

        public static void RemoveProduct(ProductCatalogue product)
        {
            //Task.Run(async () =>
            //{ return await 
            ConnectToProductServices(ProductCatalogueRemove, JsonConvert.SerializeObject(product));
            //});
        }

        public static ProductPricing GetProductPricing(ProductPricing product)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            //Task.Run(async () =>
            //{
            response = ConnectToProductServices(ProductPricingGet, JsonConvert.SerializeObject(product));
            var result = response.Content.ReadAsStringAsync().Result;
            product = JsonConvert.DeserializeObject<ProductPricing>(result);
            return product;
            //});
            //return product;
        }

        private static HttpResponseMessage ConnectToProductServices(string url, string inputJson)
        {
            //Task.Run(() =>
            //{
            var reqString = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    if (!string.IsNullOrEmpty(inputJson))
                    {
                        response = client.PostAsync(url, reqString).Result;
                    }
                    else
                    {
                        response = client.GetAsync(url).Result;
                    }
                }
            }
            catch (Exception ex) { throw; }
            return response;
            //});
        }
    }

    public sealed class ProductSearchResults {
        public ProductSearchResults()
        {
            Products = new List<ProductCatalogue>();
        }
        public List<ProductCatalogue> Products { get; set; }
    }
}