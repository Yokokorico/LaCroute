using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCroute.Data;
using LaCroute.Models;
using Microsoft.AspNetCore.Authorization;


namespace LaCroute
{
    [Authorize]
    public class AdminBookingModelController : Controller
    {
        private readonly LaCrouteContext _context;

        public AdminBookingModelController(LaCrouteContext context)
        {
            _context = context;
        }

        // GET: AdminBookingModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: AdminBookingModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingModel = await _context.Books
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookingModel == null)
            {
                return NotFound();
            }

            return View(bookingModel);
        }

        // GET: AdminBookingModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminBookingModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date,time,name,phoneNumber,seats,created_at,updated_at")] BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                bookingModel.created_at = DateTime.Now;
                bookingModel.updated_at = DateTime.Now;

                _context.Add(bookingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingModel);
        }

        // GET: AdminBookingModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingModel = await _context.Books.FindAsync(id);
            if (bookingModel == null)
            {
                return NotFound();
            }
            return View(bookingModel);
        }

        // POST: AdminBookingModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,date,time,name,phoneNumber,seats,created_at,updated_at")] BookingModel bookingModel)
        {
            if (id != bookingModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingBooking = await _context.Books.AsNoTracking().FirstOrDefaultAsync(e => e.id == id);

                    if (existingBooking != null)
                    {
                        bookingModel.created_at = existingBooking.created_at;
                    }

                    bookingModel.updated_at = DateTime.Now;

                    _context.Update(bookingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingModelExists(bookingModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookingModel);
        }

        // GET: AdminBookingModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingModel = await _context.Books
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookingModel == null)
            {
                return NotFound();
            }

            return View(bookingModel);
        }

        // POST: AdminBookingModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingModel = await _context.Books.FindAsync(id);
            if (bookingModel != null)
            {
                _context.Books.Remove(bookingModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingModelExists(int id)
        {
            return _context.Books.Any(e => e.id == id);
        }
    }
}
