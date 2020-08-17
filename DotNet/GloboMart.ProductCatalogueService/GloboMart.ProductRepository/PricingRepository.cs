using GloboMart.Entities;
using GloboMart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GloboMart.ProductRepository
{
    public class PricingRepository : IRepository<ProductPricing>
    {
        public PricingRepository()
        {
            RedisWrapper.Database = 1;
            RedisWrapper.RedisKey = "Pricing";
        }
        //--> Only Get product pricing is implemented
        public async Task<ProductPricing> Get(int id) =>
             await RedisWrapper.GetValue<ProductPricing>(id);

        public void Add(ProductPricing entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPricing>> Find(Expression<Func<ProductPricing, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductPricing entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductPricing>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
