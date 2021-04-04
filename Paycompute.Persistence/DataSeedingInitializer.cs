using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Persistence
{
    public class DataSeedingInitializer
    {
        public static async Task UserAndRoleSeedAync(UserManager<IdentityUser> userManager, 
                                               RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Manager", "Staff" };
            foreach(var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create the admin user of the app
            if (userManager.FindByEmailAsync("ddragon1128@hotmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "ddragon1128@hotmail.com",
                    Email = "ddragon1128@hotmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if(identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            // Create the manager user of the app
            if (userManager.FindByEmailAsync("manager@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "manager@gmail.com",
                    Email = "manager@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password2").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            // Create the staff user of the app
            if (userManager.FindByEmailAsync("staff@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "staff@gmail.com",
                    Email = "staff@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password3").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();
                }

            }

            // Create the no role user of the app
            if (userManager.FindByEmailAsync("user@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password4").Result;
                // No role assigned to this user

            }



        }
    }
}
