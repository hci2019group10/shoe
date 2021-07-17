using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class ProductDAOImp:IProductDAO
    {
        private shoeContext _context;

        public ProductDAOImp(shoeContext ShoeContext)
        {
            _context = ShoeContext;
        }

        public List<Product> getAllProduct() //lấy tất cả sản phẩm
        {
            List<Product> list = _context.Products.ToList();
            return list;
        }

        public List<Product> getAllProductByGender(string gender) // lấy tất cả sản phẩm theo giới tính
        {
            List<Product> list = _context.Products.Where(o=>o.Gender==gender).Take(8).ToList();
            return list;
        }

        public Product getProductById(int id) // lấy sản phẩm theo mã sản phẩm
        {
            Product p = (Product)_context.Products.Where(o => o.ProductId == id).FirstOrDefault();
            return p;
        }

        public List<Product> searchProduct(string keyWork) //tìm kiếm sản phẩm
        {
            List<Product> list = _context.Products.Where(o => o.ProductName.Contains(keyWork) ||
                                                              o.Gender.Contains(keyWork) ||
                                                              o.Color.Contains(keyWork)).ToList();
            return list;
        }

      
    }
}
