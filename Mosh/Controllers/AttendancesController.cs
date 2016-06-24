using Microsoft.AspNet.Identity;
using Mosh.Models;
using System.Linq;
using System.Web.Http;

namespace Mosh.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Attend(int gigId)
        {
            var userId = User.Identity.GetUserId();
            var exists = db.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId);
            if (!exists)
            {
                var attendance = new Attendance
                {
                    GigId = gigId,
                    AttendeeId = userId,
                };

                db.Attendances.Add(attendance);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Isso ja existe");
            }

        }
    }
}
