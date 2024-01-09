using System.Diagnostics;
using LaCroute.Data;
using LaCroute.Models;
using LaCroute.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Controllers
{

    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly LaCrouteContext _context;
        public ReviewController(ILogger<ReviewController> logger, LaCrouteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review([Bind("Name,Rating,Description")] ReviewModel review)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Test");
                _context.Add(review);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Votre avis à bien été pris en compte";
                return RedirectToAction(nameof(review));
            }
            return View(review);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
