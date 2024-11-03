using System.Linq;
using System.Web.Mvc;
using NewShop.Models;
using Shop.Models;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        private readonly Model1 _context;

        public ShopController()
        {
            _context = new Model1();
        }

        // GET: Giỏ hàng
        //[Authorize]
        public ActionResult Cart()
        {
            // Giả sử ID của giỏ hàng được lưu trong Session
            var userId = (int?)Session["UserId"];
            var cartItems = _context.CartItem
                .Include("Product") // Tải sản phẩm
                .Where(ci => ci.CartID == userId)
                .ToList();

            var model = new CartViewModel
            {
                CartItems = cartItems // Gán danh sách sản phẩm trong giỏ hàng cho model
            };

            return View(model);
        }

        // Phương thức thêm sản phẩm vào giỏ hàng
        //[Authorize]
        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var userId = (int?)Session["UserId"];
            var existingCartItem = _context.CartItem
                .FirstOrDefault(ci => ci.CartID == userId && ci.ProductID == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                var product = _context.Product.Find(productId);
                if (product != null)
                {
                    var newCartItem = new CartItem
                    {
                        CartID = userId,
                        ProductID = productId,
                        Quantity = quantity,
                        Price = product.Price
                    };
                    _context.CartItem.Add(newCartItem);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        // Phương thức xóa sản phẩm khỏi giỏ hàng
        //[Authorize]
        [HttpPost]
        public ActionResult RemoveFromCart(int cartItemId)
        {
            var cartItem = _context.CartItem.Find(cartItemId);
            if (cartItem != null)
            {
                _context.CartItem.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }
    }
}
