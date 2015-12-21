using Final_Capstone___PCTC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Final_Capstone___PCTC.Controllers
{
    public class HomeController : Controller
    {
        public PCTCRepository Repo { get; set; }

        public ActionResult Index()
        {
            
            string user_id = User.Identity.GetUserId();
            ApplicationUser realUser = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
            PCTCUser the_user_logged_in = null;
            try
            {
                the_user_logged_in = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();
            }
            catch (Exception)
            {
                bool successful = Repo.CreatePCTCUser(realUser);
                if (successful)
                {

                }
                else
                {
                    int s = 1; //What is s?
                }
            }

            List<TimeCapsule> my_tcs = Repo.GetAllTCs();
            return View(my_tcs);
        }

        public HomeController()
        {
            Repo = new PCTCRepository();
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