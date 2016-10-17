using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace SOAPService
{
    public class ShopService : IShopService
    {
        JavaScriptSerializer json = new JavaScriptSerializer();
        String path = @"D:\Shops.txt";

        public void OptionsRequest() { }

        public List<Shop> GetShops()
        {
            string text = System.IO.File.ReadAllText(path);
            List<Shop> shopsArray = json.Deserialize<List<Shop>>(text);
            return shopsArray == null ? new Shop[0].ToList() : shopsArray;
        }

        public Shop CreateShop(string name, string time, string adress)
        {
            List<Shop> shops = GetShops();
            
            Shop shop = new Shop();
            shop.Id = shops.Count == 0 ? 1 : shops.Last().Id + 1;
            shop.Name = name;
            shop.Adress = adress;
            shop.Time = time;
            shop.Neighbors = new Shop[0];
            shops.Add(shop);

            System.IO.File.WriteAllText(path, json.Serialize(shops));

            return shop;
        }

        public Shop UpdateShop(int id, string name, string time, string adress)
        {
            List<Shop> shops = GetShops();
            int index = shops.FindIndex(a => a.Id == id);

            shops[index].Name = name;
            shops[index].Adress = adress;
            shops[index].Time = time;

            System.IO.File.WriteAllText(path, json.Serialize(shops));

            return shops[index];
        }

        public void DeleteShop(int id)
        {
            List<Shop> shops = GetShops();
            shops.RemoveAt(shops.FindIndex(a => a.Id == id));

            System.IO.File.WriteAllText(path, json.Serialize(shops));
        }
    }
}
