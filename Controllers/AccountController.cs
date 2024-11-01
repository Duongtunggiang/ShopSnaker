using NewShop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            var context = new Model1();
            _accountService = new AccountService(context);
        }

        [AllowAnonymous]
        public ActionResult RegisterSaler()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Mật khẩu không khớp!");
                return View();
            }

            if (_accountService.RegisterUser(username, password, "Customer"))
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lỗi! Tên người dùng đã được sử dụng!");
            return View();
        }


        [HttpPost]
        public ActionResult RegisterSaler(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Mật khẩu không khớp!");
                return View();
            }

            if (_accountService.RegisterUser(username, password, "Saler"))
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "Lỗi! Tên người dùng đã được sử dụng!");
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _accountService.LoginUser(username, password);
            if (user != null && user.Role != null)
            {
                Session["UserRole"] = user.Role.RoleName;
                Session["Username"] = user.Username;

                if (user.Role.RoleName == "Admin")
                {
                    return RedirectToAction("AdminDashboard");
                }
                else if (user.Role.RoleName == "Saler")
                {
                    return RedirectToAction("SalerDashboard");
                }
                else if (user.Role.RoleName == "Customer")
                {
                    return RedirectToAction("CustomerDashboard");
                }
            }
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View();
        }

        public ActionResult AdminDashboard()
        {
            return RedirectToAction("AdminDashboard", "Admin");
        }

        public ActionResult SalerDashboard()
        {
            return RedirectToAction("SalerDashboard", "Saler");
        }
        [AllowAnonymous]
        public ActionResult CustomerDashboard()
        {
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}