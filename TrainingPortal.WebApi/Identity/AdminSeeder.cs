using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrainingPortal.WebApi.Models;

namespace TrainingPortal.WebApi.Identity
{
    public class AdminSeeder
    {
        public static void SeedAdmin()
        {
            ApplicationDbContext context =
                new ApplicationDbContext();

            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>
                (
                    new UserStore<ApplicationUser>(context)
                );

            var user =
                userManager.FindByEmail(
                    "admin@training.com");

            if (user == null)
            {
                ApplicationUser admin =
                    new ApplicationUser
                    {
                        UserName = "admin@training.com",
                        Email = "admin@training.com"
                    };

                var result =
                    userManager.Create(
                        admin,
                        "Admin@123");

                if (result.Succeeded)
                {
                    userManager.AddToRole(
                        admin.Id,
                        "Admin");
                }
            }
        }
    }
}