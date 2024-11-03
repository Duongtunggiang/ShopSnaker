using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewShop.Models
{
    public class HomeViewModel
    {
        public List<Category> Category { get; set; }
        public List<Product> Product { get; set; }
        public Product ProductDetail { get; set; }
    }
}