using CookieAuthentication.Authentication;
using CookieAuthentication.Model.Abstract;
using CookieAuthentication.Model.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieAuthentication.Controllers
{
    public class BaseController : Controller
    {
        public IRepository repository { get; set; }

        [Inject]
        public IAuthentication Auth
        {
            get; set;
        }

        public User CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }

        public BaseController(IRepository repo)
        {
            repository = repo;
        }
    }
}