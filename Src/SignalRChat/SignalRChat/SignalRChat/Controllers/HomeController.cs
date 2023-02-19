using SignalRChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        ChatDbEntities3 db = new ChatDbEntities3();
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
         
            User ad = db.Users.Where(x =>  x.Email == user.Email && x.Password == user.Password).SingleOrDefault();
            if (ad!= null)
            {
                Session["Id"] = ad.id.ToString();
                Session["Name"] = ad.Name;
              return  RedirectToAction("Chat");
            }
            else
            {
                ViewBag.error = "Invalid username or password";
            }
            return View();
        }
        public ActionResult Signup()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                ChatDbEntities3 db = new ChatDbEntities3();
                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Login");
        }

    }
}