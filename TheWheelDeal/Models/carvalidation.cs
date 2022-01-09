using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheWheelDeal.Models
{
    [MetadataType(typeof(carregMetaData))]
    public partial class carreg
    {
        public class carregMetaData
        {
            [DisplayName("CarNo")]
            public string CarNumber { get; set; }

            [DisplayName("Company")]
            public string Make { get; set; }

            [DisplayName("Model")]
            public string Model { get; set; }
            [DisplayName("Available")]
            public string Available { get; set; }

        }
    }
}