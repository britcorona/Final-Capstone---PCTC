using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Capstone___PCTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return View();

            // 1. Create or Get a list of things
            List<string> my_list_of_things = new List<string>();
            my_list_of_things.Add("Timmy");
            my_list_of_things.Add("Chef");
            my_list_of_things.Add("Greg");
            return View(my_list_of_things);
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