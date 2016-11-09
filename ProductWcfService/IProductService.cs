using ProductWcfService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        void AddProduct(string productName, string description, DateTime creationDate);

        [OperationContract]
        void DeleteProduct(int productID);

        [OperationContract]
        void UpdateRecord(int productID, Product updatedProduct);
    }
}
