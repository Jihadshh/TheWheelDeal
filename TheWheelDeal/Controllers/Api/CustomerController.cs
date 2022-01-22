using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TheWheelDeal.Models;

namespace TheWheelDeal.Controllers.Api
{
   
    public class CustomerController : ApiController
    {
        private supercarEntities db = new supercarEntities();

        [HttpGet]
        public List<customer> Get()
        {
            return db.customers.ToList();
        }

        [HttpPost]
        public void Post(customer customer)
        {

            if (ModelState.IsValid)
            {
                db.customers.Add(customer);
                db.SaveChanges();

            }
        }
        [HttpPut]
        public void Put(customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            customer customer = db.customers.Find(id);
            db.customers.Remove(customer);
            db.SaveChanges();
        }
    }
}
