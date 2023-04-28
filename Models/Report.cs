using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiamondInventory.Models
{
    public class Report
    {
        public  string Work { get; set; }
        public string Work_Date { get; set; }
        public string Workername { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }

        public string BloodGroup { get; set; }
        public string Worktype { get; set; }
        public decimal Price { get; set; }

    }
}