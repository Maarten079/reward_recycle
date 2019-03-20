using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RewardRecycle.Models
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUserModel> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                ApplicationUserModel user = new ApplicationUserModel()
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Test123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "ADMIN").Wait();
                }
            }
        }
    }
}
