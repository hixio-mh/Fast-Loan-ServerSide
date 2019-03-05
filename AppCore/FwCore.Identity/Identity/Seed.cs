using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.Identity
{
    public class Seed
    {
        public static async Task Initialize(ApplicationDbContext context,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();


            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string role2 = "Manager";
            string desc2 = "This is the manager role";

            string role3 = "User";
            string desc3 = "This is the User role";

            string password = "1234";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }


            if (await userManager.FindByNameAsync("rakib") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "rakib",
                    Email = "rakib@gmail.com",
                    FirstName = "Rakibul",
                    LastName = "Islam"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }

            }


            if (await userManager.FindByNameAsync("iqbal") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "iqbal",
                    Email = "iqbal@gmail.com",
                    FirstName = "Iqbal",
                    LastName = "Hasan"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }

            }

            if (await userManager.FindByNameAsync("noman") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "noman",
                    Email = "noman@gmail.com",
                    FirstName = "Al",
                    LastName = "Noman"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role3);
                }

            }


        }


    }
}

