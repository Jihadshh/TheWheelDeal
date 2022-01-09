using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWheelDeal.Models;

namespace TheWheelDeal.Controllers
{

    public class returncarController : Controller
    {
        supercarEntities db = new supercarEntities();
        // GET: returncar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(returncar recar)
        {
            if (ModelState.IsValid)
            {
                db.returncars.Add(recar);
                var car = db.carregs.SingleOrDefault(e => e.CarNumber == recar.CarNumber);
                if(car == null)
                {
                    return HttpNotFound("Car number not found");
                }
                car.Available = "yes";
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recar);
        }
        [HttpPost]
        public ActionResult Getid(String carno)
        {
            var carn = (from s in db.rentals
                        where s.CarId == carno
                        select new
                        {
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                            Custid = s.CustId,
                            CarNo = s.CarId,
                            Fee = s.Fee,
                            ElapsedDays = SqlFunctions.DateDiff("day", s.EndDate, DateTime.Now)

                        }).ToArray();
            return Json(carn, JsonRequestBehavior.AllowGet);
        }
    }
}