using Shoe.Models.DBModels;
using Shoe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class ProductServiceImp : IProductService
    {
        private IProductDAO productDAO;
        public ProductServiceImp(IProductDAO product)
        {
            productDAO = product;
        }

        public List<Product> getAllProduct()
        {
            return productDAO.getAllProduct();
        }

        public List<Product> getAllProductByGender(string gender)
        {
            return productDAO.getAllProductByGender(gender);
        }

        public Product getProductById(int id)
        {
            return productDAO.getProductById(id);
        }

        public List<Product> searchProduct(string keyWork)
        {
            return productDAO.searchProduct(keyWork);
        }
    }
}
