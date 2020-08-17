using GloboMart.Entities;
using GloboMart.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboMart.ProductRepository
{
    public class ProductCatalogueRepository : IRepository<ProductCatalogue>
    {
        public ProductCatalogueRepository()
        {
            RedisWrapper.RedisKey = "Product";
            RedisWrapper.Database = 0;
        }
        //--> GetProduct, FindProducts, Add/Delete a product
        public void Add(ProductCatalogue product) =>
            RedisWrapper.SetValue(product, product.ID);

        public  Task<IEnumerable<ProductCatalogue>> Find(Expression<Func<ProductCatalogue, bool>> predicate)
        {
            return Task.Run(() => { return RedisWrapper.GetAllValues<ProductCatalogue>().AsQueryable().Where(predicate).AsEnumerable(); });
        }

        public async Task<ProductCatalogue> Get(int productID) =>
            await RedisWrapper.GetValue<ProductCatalogue>(productID);

        public Task<IEnumerable<ProductCatalogue>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductCatalogue product) =>
            RedisWrapper.DeleteValue(product.ID);

        public async Task<List<ProductCatalogue>> Search(string criteria, string searchText)
        {
            List<ProductCatalogue> listProducts = new List<ProductCatalogue>();
            switch (criteria)
            {
                case "ID":
                    listProducts = await Task.Run(() => Find(p => p.ID.Equals(searchText)).Result.ToList());
                    break;
                case "Name":
                    listProducts = await Task.Run(() => Find(p => p.Name.Equals(searchText)).Result.ToList());
                    break;
                case "ProductType":
                    listProducts = await Task.Run(() => Find(p => p.ProductType.Equals(searchText)).Result.ToList());
                    break;
                 default:
                    listProducts = RedisWrapper.GetAllValues<ProductCatalogue>().ToList();
                    break;
            }
            return listProducts;
        }
    }
}
