using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class CartItemDAOImp : ICartItemDAO
    {
        private shoeContext _context;
        public CartItemDAOImp(shoeContext shoeContext)
        {
            _context = shoeContext;
        }
        public CartItem addCartItem(int userID, int productID, int quantity)
        {
            CartItem Item = new CartItem();
            Item.UserId = userID;
            Item.ProductId = productID;
            Item.Quantity = 1;
             _context.CartItems.Add(Item);
            _context.SaveChanges();
            return Item;
        }

        public bool deleteCartItem(int cartItemID)
        {
            var cartItem = _context.CartItems.Where(o => o.Id == cartItemID).FirstOrDefault();
            if(cartItem!= null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
                return true;
            }
            return false;
           
           
        }

        public CartItem GetCartItem(int userID, int productID)
        {
            CartItem cartItem = _context.CartItems.Where(o => o.UserId == userID && o.ProductId == productID).FirstOrDefault();
            return cartItem;
        }

        public List<CartItem> getListCartItem(int userUD)
        {
            List<CartItem> listCartItem = _context.CartItems.Where(o => o.UserId == userUD).ToList();
            return listCartItem;
        }

        public CartItem updateQuantity(CartItem item)
        {
            _context.CartItems.Update(item);
            _context.SaveChanges();
            return item;
        }

      

    }
}
