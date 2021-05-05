using CookieAuthentication.Model.Abstract;
using CookieAuthentication.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAuthentication.Model.Concrete
{
    public partial class EFRepository : IRepository
    {
        private EFDbContext context = new EFDbContext();
    }
}
