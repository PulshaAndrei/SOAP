using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPService
{
    [ServiceContract(Namespace = "http://dszss.proitr.ru/WCF")]
    public interface IShopService
    {
        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "Shops")]
        void OptionsRequest();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Shops")]
        List<Shop> GetShops();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Shops?name={name}&time={time}&adress={adress}")]
        Shop CreateShop(string name, string time, string adress);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Shops?id={id}&name={name}&time={time}&adress={adress}")]
        Shop UpdateShop(int id, string name, string time, string adress);

        [OperationContract]
        [WebInvoke(Method = "DELETE")]
        void DeleteShop(int id);
    }

    [DataContract]
    public class Shop
    {
        int id;
        string name;
        string adress;
        string time;
        Shop[] neighbors;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        [DataMember]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        [DataMember]
        public Shop[] Neighbors
        {
            get { return neighbors; }
            set { neighbors = value; }
        }
    }
}
