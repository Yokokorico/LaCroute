using System.Diagnostics;
using LaCroute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaCroute.Data;


namespace LaCroute.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly LaCrouteContext _context;


        public MenuController(ILogger<MenuController> logger, LaCrouteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Product.Include(p => p.Type).Include(p => p.ProductLabel).ThenInclude(pl => pl.Label).ToListAsync();
            var types = await _context.Type.ToListAsync();

            var productLabels = products.ToDictionary(
                p => p.Id,
                p => p.ProductLabel.Select(pl => pl.Label).ToList()
            );

            var viewModel = new MenuViewModel
            {
                Products = products,
                Types = types,
                ProductLabels = productLabels
            };

            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
