using NewShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>(); // Khởi tạo danh sách
        public decimal TotalPrice => CartItems.Sum(item => (item.Quantity ?? 0) * (item.Price ?? 0)); // Tổng giá tiền của giỏ hàng

    }
}