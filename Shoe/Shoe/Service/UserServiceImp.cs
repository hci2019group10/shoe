using Shoe.DAO;
using Shoe.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe.Service
{
    public class UserServiceImp : IUserService
    {
        private IUserDAO userDAO;
        public UserServiceImp(IUserDAO user)
        {
            userDAO = user;
        }
        public User login(User userLogin)
        {
            return userDAO.login(userLogin);
        }
    }
}
