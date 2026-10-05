using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrainingPortal.WebApi.Models;

namespace TrainingPortal.WebApi.Identity
{
    public class RoleSeeder
    {
        public static void SeedRoles()
        {
            ApplicationDbContext context =
                new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager =
                new RoleManager<IdentityRole>
                (
                    new RoleStore<IdentityRole>(context)
                );

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(
                    new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("Trainer"))
            {
                roleManager.Create(
                    new IdentityRole("Trainer"));
            }

            if (!roleManager.RoleExists("Employee"))
            {
                roleManager.Create(
                    new IdentityRole("Employee"));
            }
        }
    }
}