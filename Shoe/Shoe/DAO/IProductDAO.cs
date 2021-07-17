using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
   public interface IProductDAO
    {
        public List<Product> getAllProduct(); //lấy tất cả sản phẩm
        public List<Product> getAllProductByGender(string gender); // lấy tất cả sản phẩm theo giới tính
        public Product getProductById(int id);  // lấy sản phẩm theo mã sản phẩm
       public List<Product> searchProduct(string keyWork); //tìm kiếm sản phẩm


    }
}
