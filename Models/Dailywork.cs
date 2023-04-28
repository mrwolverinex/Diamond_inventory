using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiamondInventory.Models
{
    public class Dailywork
    {
         
        public Guid DailyworkID { get; set; }
        [Required(ErrorMessage = "Please Enter ")]

        public Guid WorkerID { get; set; }

        [Required(ErrorMessage = "Please Enter valid value")]

        public int Work { get; set; }
        public DateTime Work_Date { get; set; }
        public int seqNo { get; set; }
        public string Createdby { get; set; }
        public string Createdon { get; set; }
        public string Updatedby { get; set; }
        public DateTime Updatedon { get; set; }
        public string Updatedlog { get; set; }

    }

    public class Dailywork_list
    {

        public Guid DailyworkID { get; set; }
        public Guid WorkerID { get; set; }
        public int Work { get; set; }
        public DateTime Work_Date { get; set; }
        public int seqNo { get; set; }
        public string Createdby { get; set; }
        public string Createdon { get; set; }
        public string Updatedby { get; set; }
        public DateTime Updatedon { get; set; }
        public string Updatedlog { get; set; }

        public string WorkerName { get; set; }
        public string WorkType { get; set; }
        public decimal price { get; set; }
    }

}
