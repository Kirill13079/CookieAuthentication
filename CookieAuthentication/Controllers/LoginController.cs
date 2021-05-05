using CookieAuthentication.Authentication;
using CookieAuthentication.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieAuthentication.Controllers
{
    public class LoginController : Controller
    {
        [Inject]
        public IAuthentication Auth
        {
            get; set;
        }
        [HttpGet] 
        public ActionResult Index() 
        { 
            return View(new LoginView()); 
        }
        public ActionResult Index(LoginView loginView)
        {
            if (ModelState.IsValid) 
            {
               
                var user = Auth.Login(loginView.Email, loginView.Password, loginView.IsPersistent);
                if (user != null)
                {
                    return RedirectToAction("MyProfile");
                }
                else
                {
                    ModelState.AddModelError("Email", "Enter the correct username");
                    ModelState.AddModelError("Password", "Enter the correct password");
                }
               
            }
            return View(loginView);
        }

        public ActionResult MyProfile()
        {
            var user = ((UserIndentity)Auth.CurrentUser.Identity).User;
            if(user != null )
            return View(user);
            else return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout() { Auth.LogOut(); return RedirectToAction("Index", "Home"); }


    }
}