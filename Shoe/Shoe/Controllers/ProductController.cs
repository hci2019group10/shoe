using Microsoft.AspNetCore.Mvc;
using Shoe.Models.DBModels;
using Shoe.Service;
using Shoe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Controllers
{
    public class ProductController : Controller
    {
        private IProductService ProductService;
        public ProductController(IProductService Product)
        {
            ProductService = Product;
        }
        public IActionResult ProductDetail(int id)
        {
            ViewBag.Detail = ProductService.getProductById(id);
            return View();
        }
        public IActionResult Search( string keyword)
        {
            ViewBag.ListProduct = ProductService.searchProduct(keyword);
            ViewBag.ListProductSize = ProductService.searchProduct(keyword).Count();
            return View("ListProduct");
        }

        public IActionResult ListProduct(string keywork)
        {
            ViewBag.ListProduct = ProductService.searchProduct(keywork);
            ViewBag.ListProductSize = ProductService.searchProduct(keywork).Count();
            return View();
        }
    }
}
