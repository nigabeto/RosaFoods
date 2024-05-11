using Microsoft.AspNetCore.Mvc;
using RosaFoods.Models;
using System.Diagnostics;

namespace RosaFoods.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            TempData["Nome"] = "Nigabeto";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
