using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using System.Diagnostics;
using Shoe.DAO;
using Shoe.Models;
using Shoe.Service;

namespace Shoe.Controllers
{
    public class HomeController : Controller
    {
        private IProductService ProductService;

        public HomeController(IProductService Product)
        {
            ProductService = Product;
        }

        public IActionResult Index()
        {
            ViewBag.MaleProduct = ProductService.getAllProductByGender("nam");
            ViewBag.FeMaleProduct = ProductService.getAllProductByGender("nữ");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
