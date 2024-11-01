using NewShop.Models;
using System;
using System.Linq;
using System.Web.Helpers; 

namespace Shop.Services
{
    public class AccountService
    {
        private readonly Model1 _context;

        public AccountService(Model1 context)
        {
            _context = context;
        }

        //public bool RegisterUser(string username, string password, string roleName)
        //{
        //    // Kiểm tra xem username đã tồn tại chưa
        //    bool exists = _context.Account.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        //    if (exists)
        //    {
        //        Console.WriteLine("Tên tài khoản đã được sử dụng: " + username);
        //        return false;
        //    }

        //    // Tìm vai trò trong cơ sở dữ liệu
        //    var role = _context.Role.FirstOrDefault(r => r.RoleName == roleName);
        //    if (role == null)
        //    {
        //        Console.WriteLine("Vai trò không hợp lệ: " + roleName);
        //        return false; // Nếu vai trò không tồn tại
        //    }

        //    // Tạo tài khoản mới với mật khẩu đã mã hóa
        //    var user = new Account
        //    {
        //        Username = username,
        //        Password = Crypto.HashPassword(password), // Mã hóa mật khẩu
        //        Role = role // Gán vai trò đã tìm thấy
        //    };

        //    _context.Account.Add(user);

        //    try
        //    {
        //        _context.SaveChanges();
        //        Console.WriteLine("Tài khoản đã được tạo thành công: " + username);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi tạo tài khoản: " + ex.Message);
        //        return false;
        //    }

        //    return true;
        //}
        /*public bool RegisterUser(string username, string password, string roleName)
        {
            // Kiểm tra xem tài khoản đã tồn tại chưa
            if (_context.Account.Any(u => u.Username == username))
            {
                return false; // Tên đăng nhập đã tồn tại
            }

            // Mã hóa mật khẩu
            var hashedPassword = HashPassword(password);

            // Tìm kiếm Role dựa trên roleName
            var role = _context.Role.FirstOrDefault(r => r.RoleName == roleName);
            if (role == null)
            {
                return false; // Role không tồn tại
            }

            // Tạo tài khoản mới và gán role
            var user = new Account
            {
                Username = username,
                Password = hashedPassword,
                Role = role // Gán role cho user
            };

            _context.Account.Add(user);
            _context.SaveChanges();

            return true; // Đăng ký thành công
        }*/
        private string HashPassword(string password)
        {
            // Implement hashing here
            return password; // Replace with actual hashing logic
        }
        public bool RegisterUser(string username, string password, string roleName)
        {
            if (_context.Account.Any(u => u.Username == username))
                return false;

            var user = new Account
            {
                Username = username,
                Password = Crypto.HashPassword(password),
                Role = _context.Role.FirstOrDefault(r => r.RoleName == roleName)
            };

            if (user.Role == null)
            {
                return false; // Role không tồn tại
            }

            _context.Account.Add(user);
            _context.SaveChanges();

            return true;
        }

        public Account LoginUser(string username, string password)
        {
            // Tìm người dùng theo tên tài khoản
            var user = _context.Account.FirstOrDefault(u => u.Username == username);
            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {
                return user; // Trả về người dùng nếu xác thực thành công
            }
            return null; // Trả về null nếu không tìm thấy người dùng hoặc mật khẩu không đúng
        }
    }
}
