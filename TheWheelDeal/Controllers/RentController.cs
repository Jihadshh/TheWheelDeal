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
            var result = (from r in db.rentals
                          join c in db.carregs on r.CarId equals c.CarNumber
                          select new RentalViewModel
                          {
                              RentId = r.RentId,
                              CarId = r.CarId,
                              CustId = r.CustId,
                              Fee = r.Fee,
                              StartDate = r.StartDate,
                              EndDate = r.EndDate,
                              Available = c.Available

                          }).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Getcar()
        {
            var car = db.carregs.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Getid(String name)
        {
           var customer = (from s in db.customers where s.CustName==name select s.CustId).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Getavil(String carno)
        {
            var caravil = (from s in db.carregs where s.CarNumber == carno select s.Available).FirstOrDefault();
            return Json(caravil, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(rental rent)
        {
            if (ModelState.IsValid) 
            {
                db.rentals.Add(rent);
                var car = db.carregs.SingleOrDefault(e=>e.CarNumber == rent.CarId);
                if (car == null)
                {
                    return HttpNotFound("Car number is not valid");
                }
                car.Available = "no";
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rent);
        }



    }
}