using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewShop.Models;

namespace NewShop.Controllers
{
    //[Authorize(Roles = "Saler")]
    public class SalerController : Controller
    {
        private readonly Model1 _context;

        public SalerController()
        {
            _context = new Model1(); // Khởi tạo context
        }

        // GET: Saler Dashboard
        public ActionResult SalerDashboard()
        {
            return View();
        }

        // GET: Danh sách sản phẩm
        public ActionResult MyProducts()
        {
            var products = _context.Product.ToList(); // Lấy danh sách sản phẩm từ database
            return View(products);
        }

        // GET: Chi tiết sản phẩm
        public ActionResult ProductDetails(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Thêm sản phẩm
        public ActionResult CreateProduct()
        {
            ViewBag.CategoryID = new SelectList(_context.Category.ToList(), "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase ProductImagePath)
        {
            if (ModelState.IsValid)
            {
                if (ProductImagePath != null && ProductImagePath.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ProductImagePath.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Products"), fileName);
                    try
                    {
                        ProductImagePath.SaveAs(path);
                        product.ProductImagePath = "~/Images/Products/" + fileName; // Lưu đường dẫn hình ảnh
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Có lỗi xảy ra khi tải lên hình ảnh: " + ex.Message);
                    }
                }

                _context.Product.Add(product);
                _context.SaveChanges();
                return RedirectToAction("MyProducts");
            }

            ViewBag.CategoryID = new SelectList(_context.Category.ToList(), "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Sửa sản phẩm
        public ActionResult EditProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(_context.Category.ToList(), "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product, HttpPostedFileBase ProductImagePath)
        {
            if (ModelState.IsValid)
            {
                if (ProductImagePath != null && ProductImagePath.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ProductImagePath.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Products"), fileName);
                    ProductImagePath.SaveAs(path);
                    product.ProductImagePath = "~/Images/Products/" + fileName; // Cập nhật hình ảnh mới
                }

                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("MyProducts");
            }

            ViewBag.CategoryID = new SelectList(_context.Category.ToList(), "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Xóa sản phẩm
        public ActionResult DeleteProduct(int id)
        {
            var product = _context.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _context.Product.Find(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("MyProducts");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
