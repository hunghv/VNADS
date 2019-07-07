using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VNADS.Models;
using VNADS.Models.AccountViewModels;

namespace VNADS.Controllers
{
    public class HomeController : Controller
    {
        //[Route("")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var authResult = await HttpContext.AuthenticateAsync();
            var a = User.Identity.IsAuthenticated;
            var vm = new ProfileViewModel
            {
                Claims = authResult?.Principal?.Claims ?? new List<Claim>(),
                Name = authResult?.Principal?.Identity?.Name ?? String.Empty
            };

            return View(vm);
        }

        [Route("privacy")]
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
