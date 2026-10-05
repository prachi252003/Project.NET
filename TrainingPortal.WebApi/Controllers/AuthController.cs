using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Http;
using TrainingPortal.WebApi.Models;

namespace TrainingPortal.WebApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private ApplicationDbContext context;

        public AuthController()
        {
            context = new ApplicationDbContext();
        }

        // POST api/auth/register

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(RegisterModel model)
        {
            var userManager =
                new UserManager<ApplicationUser>
                (
                    new UserStore<ApplicationUser>(context)
                );

            var existingUser =
                userManager.FindByEmail(model.Email);

            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            ApplicationUser user =
                new ApplicationUser();

            user.UserName = model.Email;
            user.Email = model.Email;

            var result =
                userManager.Create(user, model.Password);

            if (result.Succeeded)
            {
                userManager.AddToRole(
                    user.Id,
                    model.Role);

                return Ok("User Registered");
            }

            return BadRequest(
                result.Errors.FirstOrDefault());
        }

        [HttpPost]
        [Route("assignrole")]
        public IHttpActionResult AssignRole(
        string email,
        string role)
        {
            var userManager =
                new UserManager<ApplicationUser>
                (
                    new UserStore<ApplicationUser>(context)
                );

            var user =
                userManager.FindByEmail(email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            userManager.AddToRole(
                user.Id,
                role);

            return Ok("Role Assigned");
        }
    }
}