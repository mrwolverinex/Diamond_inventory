using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiamondInventory.Models
{
    public class WorkerType
    {
        public Guid WorkTypeID { get; set; }

        [Required(ErrorMessage = "Please Enter Your TypeName")]
        public string TypeName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Price")]

        public decimal Price { get; set; }
        public int SeqNo { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Updatedby { get; set; }
        public DateTime Updatedon { get; set; }
        public string Updatedlog { get; set; }

    }
}