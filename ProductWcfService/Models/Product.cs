using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWcfService.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}