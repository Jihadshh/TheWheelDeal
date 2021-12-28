using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWheelDeal.Models;

namespace TheWheelDeal.Controllers
{
 
    public class RentController : Controller
    {
        supercarEntities db = new supercarEntities();
        // GET: Rent
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.carregs.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Getid(int id)
        {
           var customer = (from s in db.customers where s.id==id select s.custname).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Getavil(String carno)
        {
            var caravil = (from s in db.carregs where s.carno == carno select s.available).FirstOrDefault();
            return Json(caravil, JsonRequestBehavior.AllowGet);
        }

    }
}