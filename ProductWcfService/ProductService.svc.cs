using ProductWcfService.DAL;
using ProductWcfService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : ContextRepository, IProductService
    {
        public void AddProduct(string productName, string description, DateTime creationDate)
        {
            using(var context = CreateContext())
            {
                Product product = new Product() { ProductName = productName, Description = description, CreationDate = creationDate };

                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int productID)
        {
         
            using (var context = CreateContext())
            {
                var itemToRemove = context.Products.SingleOrDefault(x => x.ProductID == productID); //returns a single item.

                if (itemToRemove != null)
                {
                    context.Products.Remove(itemToRemove);
                    context.SaveChanges();
                }
            }  
        }
        public List<Product> GetAllProducts()
        {
            using (var context = CreateContext())
            {
                return context.Products.ToList();
            }       
        }

        public void UpdateRecord(int productID, Product updatedProduct)
        {
            using (var context = CreateContext())
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductID == productID);

                product.ProductName = updatedProduct.ProductName;
                product.Description = updatedProduct.Description;

                context.SaveChanges();
            }   
        }
    }
}
