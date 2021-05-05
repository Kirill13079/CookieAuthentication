using CookieAuthentication.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAuthentication.Model.Abstract
{
    public interface IRepository
    {

        IQueryable<User> Users { get; }

        User Login(string email, string password);

        bool CreateUser(User item);

        bool UpdateUser(User item);

        bool RemoveUser(int id);
        User GetUser(string email);
    }
}
