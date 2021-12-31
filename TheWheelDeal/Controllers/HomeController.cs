using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWheelDeal.Models;

namespace TheWheelDeal.Controllers
{
    
    public class HomeController : Controller
    {
        private supercarEntities db = new supercarEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registration reg)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Registration reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Registrations
                               where userlist.Username == reg.Username && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.UserId,
                                   userlist.Username
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["UserId"] = details.FirstOrDefault().UserId;
                    Session["Username"] = details.FirstOrDefault().Username;
                    return RedirectToAction("Welcome", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(reg);


        }
        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}