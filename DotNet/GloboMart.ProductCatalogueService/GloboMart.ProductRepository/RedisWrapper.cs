using GloboMart.Entities;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GloboMart.ProductRepository
{
    public static class RedisWrapper
    {
        public static string RedisKey;
        public static int Database;

        //--> Get product
        public static async Task<T> GetValue<T>(int id)
        {
            using (RedisNativeClient client = new RedisClient())
            {
                client.Db = Database;
                var result = Encoding.UTF8.GetString(client.Get(RedisKey + ":" + id));

                T product = await Task.Run(() => JsonConvert.DeserializeObject<T>(result));
                return product;
            }
        }

        //--> Set Product
        public static void SetValue<T>(T input, int id)
        {
            using (RedisNativeClient client = new RedisClient())
            {
                client.Db = Database;
                var result = JsonConvert.SerializeObject(input);
                client.Set(RedisKey + ":" + id.ToString(), Encoding.UTF8.GetBytes(result));
            }
        }

        //--> Delete product
        public static void DeleteValue(int id)
        {
            using (RedisNativeClient client = new RedisClient())
            {
                client.Db = Database;
                client.Del(RedisKey + ":" + id.ToString());
            }
        }

        //--> GetAll Products
        public static IEnumerable<T> GetAllValues<T>()
        {
            List<T> outValues = new List<T>();
            using (IRedisNativeClient client = new RedisClient())
            {
                client.Db = Database;
                var results = client.Scan(0, match: RedisKey + ":*").Results;
                foreach (var item in results)
                {
                    var keyValue = Encoding.UTF8.GetString(client.Get(Encoding.UTF8.GetString(item)));
                    outValues.Add(JsonConvert.DeserializeObject<T>(keyValue));
                }
            }
            return outValues;
        }
    }
}
