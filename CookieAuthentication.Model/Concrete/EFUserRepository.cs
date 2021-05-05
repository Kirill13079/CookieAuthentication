using CookieAuthentication.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAuthentication.Model.Concrete
{
    public partial class EFRepository
    {
        public IQueryable<User> Users 
        {
            get { return context.Users; }
        }

        public bool CreateUser(User item)
        {

            if (item.ID == 0)
            {
                item.AddedDate = DateTime.Now;
                item.ActivatedDate = DateTime.Now;
                item.LastVisitDate = DateTime.Now;
                context.Users.Add(item);
                context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool UpdateUser(User item)
        {
            User user = context.Users.Find(item.ID);
            if (user != null)
            {
                user.Email = item.Email;
                user.Password = item.Password;
                user.ActivatedLink = item.ActivatedLink;
                user.AvatarPath = item.AvatarPath;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool RemoveUser(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public User Login(string email, string password) 
        { 
            return Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0 && p.Password == password); 
        }

        public User GetUser(string email) { return Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0); }
    }
}
