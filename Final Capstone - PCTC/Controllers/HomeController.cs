using Final_Capstone___PCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Final_Capstone___PCTC.Controllers
{
    public class HomeController : Controller
    {
        public PCTCRepository Repo { get; set; }
        public ActionResult Index()
        {
            //return View();

            List<TimeCapsule> myCaps = Repo.GetAllTCs();
            return View(myCaps);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}