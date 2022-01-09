using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheWheelDeal.Models
{
    [MetadataType(typeof(customerMetaData))]
    public partial class customer
    {
        public class customerMetaData
        {
            [DisplayName("Customer Name")]
            public string CustName { get; set; }

            [DisplayName("Address")]
            public string CustAddress { get; set; }

            [DisplayName("Mobile")]
            public Nullable<int> CustMobileNumber { get; set; }
            

        }
    }
}