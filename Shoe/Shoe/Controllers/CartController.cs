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
    public class CartController : Controller
    {
        private ICartItemService ItemService;
        private IProductService ProductService;
        public CartController(ICartItemService Item, IProductService Product)
        {
            ItemService = Item;
            ProductService = Product;
        }
        public IActionResult Index()
        {
            
            if (HttpContext.Session.GetString("userName") != null)
            {
                int UserId = int.Parse(HttpContext.Session.GetString("id"));
                List<CartItem> listCart = ItemService.getListCartItem(UserId);
                List<Product> listProduct = new List<Product>();
                foreach(var item in listCart)
                {
                    Product product = ProductService.getProductById(item.ProductId);
                    listProduct.Add(product);
                }
                ViewBag.ListCartItem = listProduct;
                ViewBag.ListCart = listCart;
                
                return View();
            }
            return Redirect("/Account/Login");
        }

        [HttpPost]
        public void AddToCart(int ProductId, int quanlity)
        {
            int UserId = int.Parse(HttpContext.Session.GetString("id"));

            if (HttpContext.Session.GetString("userName") != null)
            {
                CartItem item = ItemService.GetCartItem(UserId, ProductId);
                if (item == null)
                {
                    
                    ItemService.addCartItem(UserId, ProductId, quanlity);
                }
                else if(item != null)
                {
                    
                    item.Quantity = item.Quantity+1;
                    ItemService.updateQuantity(item);
                }
                
            }
        }

        [HttpDelete]
        public void deleteCartItem(int cartItemID)
        {
            ItemService.deleteCartItem(cartItemID);
        }
    }
}
