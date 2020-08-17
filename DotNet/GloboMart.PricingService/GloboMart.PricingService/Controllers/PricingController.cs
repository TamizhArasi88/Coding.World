using GloboMart.Entities;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GloboMart.PricingService.Controllers
{
    public class PricingController : ApiController
    {
        [HttpPost]
        [Route("GloboMart/ProductPricing/Get")]
        public async Task<HttpResponseMessage> GetProductPricing(HttpRequestMessage request)
        {
            try
            {
                ProductPricing responseObj = new ProductPricing();
                var reqJSONContent = await request.Content.ReadAsStringAsync();
                var reqJSONObject = JsonConvert.DeserializeObject<ProductPricing>(reqJSONContent);

                var coreModule = new StandardKernel(new NinjectCore());
                var productCatalogueService = coreModule.Get<ProductRepository.PricingRepository>();

                responseObj = await productCatalogueService.Get(reqJSONObject.ProductID);

                return request.CreateResponse(HttpStatusCode.OK, responseObj);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
