using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DiamondInventory.Models
{
    public class Worker
    {

        public Guid WorkerId { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name")]
       
        public string Workername { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your MobileNo")]
        //[DataType(DataType.MobileNo)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobileNo")]

        public string MobileNo { get; set; }

        public string WorkType { get; set; }
        public decimal WorkPrice { get; set; }

        //public List<WorkerType> WorkType { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Your State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Your Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Enter Your BloodGroup")]
        //[RegularExpression(^(A | B | AB | O)[+-]$", ErrorMessage = "Wrong mobileNo")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Please Enter the Date")]
        public DateTime JoiningDate { get; set; }
        public int SeqNo { get; set; }
        public string Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public string Updatedby { get; set; }
        public DateTime upodatedon { get; set; }
        public string Updatedlog { get; set; }
    }
}