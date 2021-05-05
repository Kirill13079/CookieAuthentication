using CookieAuthentication.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAuthentication.Model.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
