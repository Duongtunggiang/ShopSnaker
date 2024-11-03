using NewShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly Model1 _context;
        public HomeController(Model1 context)
        {
            _context = context;
        }
        public HomeController()
        {
            _context = new Model1();
        }

        [AllowAnonymous]
        public ActionResult Index(int? categoryId, int? productId)
        {
            var categories = _context.Category.ToList();

            var products = categoryId.HasValue
                ? _context.Product.Where(p => p.CategoryID == categoryId).ToList()
                : _context.Product.ToList();

            Product productDetails = null;
            if (productId.HasValue)
            {
                productDetails = _context.Product.FirstOrDefault(p => p.ProductID == productId);
            }

            var viewModel = new HomeViewModel
            {
                Category = categories,
                Product = products,
                ProductDetail = productDetails
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult FilterProducts(List<int> categoryIds)
        {
            List<Product> products;

            if (categoryIds == null || !categoryIds.Any())
            {
                products = _context.Product.ToList();
            }
            else {

                products = _context.Product.Where(p => categoryIds.Cast<int?>().Contains(p.CategoryID)).ToList();
            }

            return PartialView("_ProductList", products);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}