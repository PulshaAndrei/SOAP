using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product[] GetProducts(int shopId);

        [OperationContract]
        Product CreateProduct(int shopId, string name, string description);

        [OperationContract]
        Product UpdateProduct(int shopId, int id, string name, string description);

        [OperationContract]
        void DeleteProduct(int shopId, int id);
    }

    [DataContract]
    public class Product
    {
        int id;
        int shopId;
        string name;
        string description;

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public int ShopId
        {
            get { return shopId; }
            set { shopId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}