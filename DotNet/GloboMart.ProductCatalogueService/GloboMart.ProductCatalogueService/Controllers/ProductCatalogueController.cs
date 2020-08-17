using GloboMart.Entities;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GloboMart.ProductCatalogueService
{
    public class ProductCatalogueController : ApiController
    {
        [HttpPost]
        [Route("GloboMart/ProductCatalogue/Search")]
        public async Task<HttpResponseMessage> SearchProduct(HttpRequestMessage request)
        {
            try
            {
                ProductResponse responseObj = new ProductResponse();

                var reqJSONContent = await request.Content.ReadAsStringAsync();
                var reqJSONObject = JsonConvert.DeserializeObject<ProductRequest>(reqJSONContent);

                var coreModule = new StandardKernel(new NinjectCore());
                var productCatalogueService = coreModule.Get<ProductRepository.ProductCatalogueRepository>();

                responseObj.Products = await productCatalogueService.Search(reqJSONObject.SearchCriteria, reqJSONObject.SearchText);
                    //await productCatalogueService.Find(p => p.ProductType.Contains(reqJSONObject.SearchText));
                        
                return request.CreateResponse(HttpStatusCode.OK, responseObj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("GloboMart/ProductCatalogue/Add")]
        public async Task<HttpResponseMessage> AddProduct(HttpRequestMessage request)
        {
            try
            {
                var reqJSONContent = await request.Content.ReadAsStringAsync();
                var reqJSONObject = JsonConvert.DeserializeObject<ProductCatalogue>(reqJSONContent);

                var coreModule = new StandardKernel(new NinjectCore());
                var productCatalogueService = coreModule.Get<ProductRepository.ProductCatalogueRepository>();

                productCatalogueService.Add(reqJSONObject);

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("GloboMart/ProductCatalogue/Delete")]
        public async Task<HttpResponseMessage> DeleteProduct(HttpRequestMessage request)
        {
            try
            {
                var reqJSONContent = await request.Content.ReadAsStringAsync();
                var reqJSONObject = JsonConvert.DeserializeObject<ProductCatalogue>(reqJSONContent);

                var coreModule = new StandardKernel(new NinjectCore());
                var productCatalogueService = coreModule.Get<ProductRepository.ProductCatalogueRepository>();

                productCatalogueService.Remove(reqJSONObject);

                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
