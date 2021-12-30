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
                var car = db.carregs.SingleOrDefault(e => e.carno == recar.carno);
                if(car == null)
                {
                    return HttpNotFound("Car number not found");
                }
                car.available = "yes";
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
                        where s.carid == carno
                        select new
                        {
                            StartDate = s.sdate,
                            EndDate = s.edate,
                            Custid = s.custid,
                            CarNo = s.carid,
                            Fee = s.fee,
                            ElapsedDays = SqlFunctions.DateDiff("day", s.edate, DateTime.Now)

                        }).ToArray();
            return Json(carn, JsonRequestBehavior.AllowGet);
        }
    }
}