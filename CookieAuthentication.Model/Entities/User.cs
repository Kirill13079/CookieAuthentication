using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAuthentication.Model.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ActivatedDate { get; set; }
        public string ActivatedLink { get; set; }
        public DateTime LastVisitDate { get; set; }
        public string AvatarPath { get; set; }
    }
}
