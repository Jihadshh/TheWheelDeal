using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheWheelDeal.Models
{
    public class RentalViewModel
    {
        public int RentId { get; set; }
        public string CarId { get; set; }
        public Nullable<int> CustId { get; set; }
        public Nullable<int> Fee { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Available { get; set; }


    }
}