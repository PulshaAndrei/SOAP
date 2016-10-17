using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;


namespace SOAPService
{
    public class ProductService : IProductService
    {
        JavaScriptSerializer json = new JavaScriptSerializer();
        String path = @"D:\Products.txt";

        public void OptionsRequest() { }

        private List<Product> GetAllProducts()
        {
            string text = System.IO.File.ReadAllText(path);
            List<Product> productsArray = json.Deserialize<List<Product>>(text);
            return productsArray == null ? new Product[0].ToList() : productsArray;
        }

        public List<Product> GetProducts(int shopId)
        {
            List<Product> productsArray = GetAllProducts();
            return productsArray.Where(a => a.ShopId == shopId).ToList();
        }

        public Product CreateProduct(int shopId, string name, string description)
        {
            List<Product> products = GetAllProducts();
            Product product = new Product();
            List<Product> shopProducts = GetProducts(shopId);
            product.ShopId = shopId;
            product.Id = shopProducts.Count == 0 ? 1 : shopProducts.Last().Id + 1;
            product.Name = name;
            product.Description = description;
            products.Add(product);

            System.IO.File.WriteAllText(path, json.Serialize(products));

            return product;
        }

        public Product UpdateProduct(int shopId, int id, string name, string description)
        {
            List<Product> products = GetAllProducts();
            int index = products.FindIndex(a => a.Id == id && a.ShopId == shopId);
            products[index].Name = name;
            products[index].Description = description;

            System.IO.File.WriteAllText(path, json.Serialize(products));

            return products[index];
        }

        public void DeleteProduct(int shopId, int id)
        {
            List<Product> products = GetAllProducts();
            products.RemoveAt(products.FindIndex(a => a.Id == id && a.ShopId == shopId));
            System.IO.File.WriteAllText(path, json.Serialize(products));
        }
    }
}
