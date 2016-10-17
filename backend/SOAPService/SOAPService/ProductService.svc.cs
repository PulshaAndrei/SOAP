using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOAPService
{
    public class ProductService : IProductService
    {
        public Product[] GetProducts(int shopId)
        {
            return new Product[0];
        }

        public Product CreateProduct(int shopId, int id, string name, string description)
        {
            Product product = new Product();
            product.Id = GetProducts(shopId).Last().Id + 1;
            product.Name = name;
            product.Description = description;

            //TODO: DB create
            return product;
        }

        public Product UpdateProduct(int shopId, int id, string name, string description)
        {
            Product product = new Product();
            product.ShopId = shopId;
            product.Id = id;
            product.Name = name;
            product.Description = description;

            //TODO: DB update
            return product;
        }

        public void DeleteProduct(int shopId, int id)
        {
            //TODO: DB delete
        }
    }
}
