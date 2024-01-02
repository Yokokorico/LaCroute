using System.Diagnostics;
using LaCroute.Data;
using LaCroute.Models;
using LaCroute.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LaCrouteContext _context;
        public HomeController(ILogger<HomeController> logger, LaCrouteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Création du ViewModel
            var viewModel = new HomeViewModel
            {
                Events = await _context.Event.OrderByDescending(e => e.created_at).Take(3).ToListAsync()
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
