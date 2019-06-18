using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using VNADS.Models;

namespace VNADS.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var authResult = await HttpContext.AuthenticateAsync();
            var a = User;
            var vm = new ProfileViewModel
            {
                Claims = authResult.Principal.Claims,
                Name = authResult.Principal.Identity?.Name
            };

            return View(vm);
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
