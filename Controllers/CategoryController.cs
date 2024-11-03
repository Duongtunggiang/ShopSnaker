using NewShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Model1 _context;

        public CategoryController()
        {
            _context = new Model1();
        }

        // GET: Danh sách danh mục
        public ActionResult Index()
        {
            var categories = _context.Category.ToList();
            return View(categories);
        }

        // GET: Thêm danh mục
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
