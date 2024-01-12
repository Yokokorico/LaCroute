using System.Diagnostics;
using LaCroute.Data;
using LaCroute.Models;
using LaCroute.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            Console.WriteLine("IM HERE -------------- "+book.date);
            DateOnly dateFormat = DateOnly.Parse(book.date.ToString("MM-dd-yyyy"));
            
            var existingEvents = await _context.Event
            .Where(e => e.date == dateFormat)
            .ToListAsync();

            bool isEventExist = existingEvents.Any();
            Console.WriteLine("IM HERE -------------- "+isEventExist);


            if (isEventExist)
            {
                Console.WriteLine("IM HERE --------------");
                ModelState.AddModelError("date", "Désolé, il y a déjà un événement à cette date. Veuillez choisir une autre date.");
                return View(book);
            }

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Votre réservation à bien été enregistrer en cas de soucis nous vous appellerons";
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
