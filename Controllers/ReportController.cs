using DiamondInventory.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiamondInventory.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        Reportrepo Report_ = new Reportrepo();
        public ActionResult Index()
        {
            var mylist = Report_.GetReportVM("1900/01/01", System.DateTime.Now.ToString("yyyy/MM/dd"));
            return View(mylist);
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            var StartDate = fc["StartDate"];
            var EndDate = fc["EndDate"];

            if (StartDate == "")
            {
                return RedirectToAction("Index");
            }
           
            if (EndDate == "")
            {
                return RedirectToAction("Index");
            }

            var mylist = Report_.GetReportVM(StartDate, EndDate);
            return View(mylist);
        }
    }
}