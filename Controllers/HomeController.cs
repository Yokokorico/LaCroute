using System.Diagnostics;
using LaCroute.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaCroute.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // Création du ViewModel
            var viewModel = new HomeViewModel
            {
                Products = await _context.Event.OrderByDescending(e => e.create_at).Take(3).ToListAsync()
            };
            // Envoi du ViewModel à la vue
            return View(viewModel);
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
