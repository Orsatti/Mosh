using Microsoft.AspNet.Identity;
using Mosh.Models;
using System.Linq;
using System.Web.Http;

namespace Mosh.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Follow(string FolloweeId)
        {
            var userId = User.Identity.GetUserId();
            var exists = db.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == FolloweeId);
            if (!exists)
            {
                var following = new Following
                {
                    FollowerId = userId,
                    FolloweeId = FolloweeId,
                };

                db.Followings.Add(following);
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
