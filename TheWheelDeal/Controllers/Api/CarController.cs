using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheWheelDeal.Models;

namespace TheWheelDeal.Controllers.Api
{
    public class CarController : ApiController
    {
        private supercarEntities db = new supercarEntities();

        [HttpGet]
        public List<carreg> Get()
        {
            return db.carregs.ToList();
        }
        [HttpPost]

        public void Post(carreg car)
        {
           
            if (ModelState.IsValid)
            {
                db.carregs.Add(car);
                db.SaveChanges();
                
            }
        }
        [HttpPut]
        public void Put(carreg carreg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreg).State = EntityState.Modified;
                db.SaveChanges();
            } 
        }
        [HttpDelete]
        public void Delete(int id)
        {
            carreg carreg = db.carregs.Find(id);
            db.carregs.Remove(carreg);
            db.SaveChanges();
        }

    }
}
