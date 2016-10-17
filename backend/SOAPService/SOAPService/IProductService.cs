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
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "Products")]
        void OptionsRequest();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Products?shopId={shopId}")]
        List<Product> GetProducts(int shopId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Products?shopId={shopId}&name={name}&description={description}")]
        Product CreateProduct(int shopId, string name, string description);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Products?shopId={shopId}&id={id}&name={name}&description={description}")]
        Product UpdateProduct(int shopId, int id, string name, string description);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Products?shopId={shopId}&id={id}")]
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