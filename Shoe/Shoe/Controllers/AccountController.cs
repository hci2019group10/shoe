using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService user)
        {
            userService = user;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoLogin([FromForm] User userLogin)
        {
            User user =  userService.login(userLogin);
            if ( user == null)
            {
                ViewBag.Error = "Thông tin đăng nhập không hợp lệ";
                return View("Login");
            }
            else if(user!=null)
            {
                ViewBag.Error = "";
                HttpContext.Session.SetString("id", user.Id.ToString());
                HttpContext.Session.SetString("userName", user.Username);
                HttpContext.Session.SetString("password", user.Password);
                HttpContext.Session.SetString("email", user.Email);

                TempData["UserName"] = HttpContext.Session.GetString("userName");
                TempData.Keep();
                
                return Redirect("/home");
            }
            return View("Login");
        }
    }
}
