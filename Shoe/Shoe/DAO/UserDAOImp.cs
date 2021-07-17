using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.DAO
{
    public class UserDAOImp : IUserDAO
    {
        private shoeContext _context;
        public UserDAOImp(shoeContext ShoeContext)
        {
            _context = ShoeContext;
        }
        public User login(User userLogin)
        {
            User user = _context.Users.Where(o => o.Email.Contains(userLogin.Email) && o.Password == userLogin.Password).FirstOrDefault();
           
            return user;
        }
    }
}
