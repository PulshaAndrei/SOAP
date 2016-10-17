using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class ShopService : IShopService
    {
        public Shop[] GetShops()
        {
            Shop[] shopsArray = new Shop[2];
            shopsArray[0] = new Shop();
            shopsArray[0].Id = 1;
            shopsArray[0].Name = "ТЦ Корона";
            shopsArray[0].Adress = "ул. Кальварийская 24, Минск";
            shopsArray[0].Time = "8.00 - 02.00";
            shopsArray[0].Neighbors = new Shop[0];

            shopsArray[1] = new Shop();
            return shopsArray;
        }

        public Shop CreateShop(string name, string time, string adress)
        {
            Shop shop = new Shop();
            shop.Id = GetShops().Last().Id + 1;
            shop.Name = name;
            shop.Adress = adress;
            shop.Time = time;
            shop.Neighbors = new Shop[0];

            //TODO: DB create
            return shop;
        }

        public Shop UpdateShop(int id, string name, string time, string adress)
        {
            Shop shop = new Shop();
            shop.Id = id;
            shop.Name = name;
            shop.Adress = adress;
            shop.Time = time;
            shop.Neighbors = new Shop[0];

            //TODO: DB update
            return shop;
        }

        public void DeleteShop(int id)
        {
            //TODO: DB delete
        }
    }
}
