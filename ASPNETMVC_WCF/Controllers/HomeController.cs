using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVC_WCF.ProductService;

namespace ASPNETMVC_WCF.Controllers
{
    public class HomeController : Controller
    {
        private ProductServiceClient psc = new ProductServiceClient();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Add new record into database
        [HttpPost]
        public ActionResult AddProduct(FormCollection formCollection)
        {
            psc.AddProduct(formCollection["product_name"], formCollection["description"], DateTime.Now);
            ViewBag.listProducts = psc.GetAllProducts();
            return PartialView("_ViewTableProducts");
        }

        //Deletes product from database and updates table in _ViewTableProducts
        [HttpPost]
        public ActionResult DeleteProduct(int productID)
        {
            psc.DeleteProduct(productID);
            ViewBag.listProducts = psc.GetAllProducts();
            return PartialView("_ViewTableProducts");
        }

        //Update row in table
        [HttpPost]
        public ActionResult UpdateList(int productID, string name, string description)
        {
            psc.UpdateRecord(productID, new Product()
                                                        {
                                                            ProductID = Convert.ToInt32(productID),
                                                            ProductName = name,
                                                            Description = description
                                                        });
            ViewBag.listProducts = psc.GetAllProducts();
            return PartialView("_ViewTableProducts");
        }

        //Set data in table
        [HttpGet]
        public ActionResult InitTableWithProducts()
        {
            ViewBag.listProducts = psc.GetAllProducts();
            return PartialView("_ViewTableProducts");
        }
    }
}