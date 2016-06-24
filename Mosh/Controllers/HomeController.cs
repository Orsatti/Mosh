using Mosh.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Mosh.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var upComingGigs = db.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now);
            ViewBag.ShowActions = User.Identity.IsAuthenticated;
            return View(upComingGigs);
        }


    }
}