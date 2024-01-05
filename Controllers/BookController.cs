using System.Diagnostics;
using LaCroute.Data;
using LaCroute.Models;
using LaCroute.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaCroute.Controllers
{

    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly LaCrouteContext _context;
        public BookController(ILogger<BookController> logger, LaCrouteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking([Bind("date,time,name,phoneNumber,seats")] Book book)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(book.time);
                _context.Add(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Votre réservation à bien été enregister en cas de soucis nous vous appellerons";
                return RedirectToAction(nameof(Booking));
            }
            return View(book);
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
