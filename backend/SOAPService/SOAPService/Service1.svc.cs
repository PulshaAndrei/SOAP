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
    public class Service1 : IService1
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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        /*public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
    }
}
