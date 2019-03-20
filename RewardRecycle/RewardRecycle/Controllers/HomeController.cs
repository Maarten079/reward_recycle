using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RewardRecycle.Models;

namespace RewardRecycle.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUserModel> _userManager;

        public HomeController(UserManager<ApplicationUserModel> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            /*
            // This way you can check the role of the current user
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            var id = _userManager.GetUserId(User); // Get user id:

            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                string role = user.SetRole(id);
            }
            */
            ViewData["Title"] = "Home";
            ViewData["Message"] = "Welcome to the website of RewardRecycle!";

            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Who are we?";

            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact information:";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
