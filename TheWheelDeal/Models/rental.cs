//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheWheelDeal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class rental
    {
        public int RentId { get; set; }
        public string CarId { get; set; }
        public Nullable<int> CustId { get; set; }
        public Nullable<int> Fee { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
