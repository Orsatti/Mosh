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

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = db.Genres.ToList(),
            };
            return View(viewModel);
        }
    }
}