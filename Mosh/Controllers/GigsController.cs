using Microsoft.AspNet.Identity;
using Mosh.Models;
using Mosh.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Mosh.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext db;

        public GigsController()
        {
            db = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = db.Genres.ToList(),
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = db.Genres.ToList();
                return View("Create", viewModel);
            }
            var userId = User.Identity.GetUserId();
            var gig = new Gig
            {
                ArtistId = userId,
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            db.Gigs.Add(gig);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}