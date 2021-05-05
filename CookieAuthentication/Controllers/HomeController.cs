using AutoMapper;
using CookieAuthentication.Captcha;
using CookieAuthentication.Model.Abstract;
using CookieAuthentication.Model.Entities;
using CookieAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CookieAuthentication.Controllers
{
    public class HomeController : BaseController
    {
      
        public HomeController(IRepository repo) : base(repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var newUser = new RegisterViewModel();
            return View(newUser);
        }

        public bool IsValidEmail(object value)
        {
            if (value == null) { return true; }
            if (!(value is string)) { return true; }
            var source = value as string; if (string.IsNullOrWhiteSpace(source)) { return true; }
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.Compiled); var match = regex.Match(source); return (match.Success && match.Length == source.Length);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        { 
            if (model.Captcha != (string)Session[CaptchaImage.CaptchaValueKey]) ModelState.AddModelError("Captcha", "The text from the picture was entered incorrectly");

            if (!IsValidEmail(model.Email)) ModelState.AddModelError("Email", "Enter correct email address");

            var anyUser = repository.Users.Any(p => string.Compare(p.Email, model.Email) == 0);
             
            if (anyUser)ModelState.AddModelError("Email", "User with this email is already registered");

            if (ModelState.IsValid)
            {
                var user = Mapper.Map<RegisterViewModel, User>(model);
                repository.CreateUser(user);
                return RedirectToAction("Index");
            }

       
            return View(model);
        }

        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] = new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(); 
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Arial");
            // Change the response headers to output a JPEG image. 
            this.Response.Clear(); this.Response.ContentType = "image/jpeg";
            // Write the image to the response stream in JPEG format
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            // Dispose of the CAPTCHA image object. 
            ci.Dispose(); return null;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            return PartialView(CurrentUser); 
        }
    }
}