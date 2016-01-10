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
        [Authorize]
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
                    the_user_logged_in = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();

                }
            }

            List<TimeCapsule> my_tcs = Repo.GetUsersTCs(the_user_logged_in);
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

        public ActionResult Contact(int? id)
        {
            TimeCapsule tcuser = Repo.Context.TimeCapsules.FirstOrDefault(tc => tc.TCId == id);
            List<BookData> my_bd = Repo.GetUsersBookData(tcuser);
            List<MovieData> my_md = Repo.GetUsersMovieData(tcuser);

            //AllData ad = new AllData();
            //ad.BookData = my_bd;
            //ad.MovieData = my_md;
            
            return View(my_bd);
        }
    }
}