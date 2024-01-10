using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCroute.Data;
using LaCroute.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;


namespace LaCroute
{
    [Authorize]
    // [Route("admin/events")]
    public class AdminEventModelController : Controller
    {

        private readonly LaCrouteContext _context;
    

        public AdminEventModelController(LaCrouteContext context)
        {
            _context = context;
        }

        //   [Route("/")]
        // GET: AdminEventModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        // GET: AdminEventModel/Details/5
        // [Route("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Event
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // GET: AdminEventModel/Create
        // [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminEventModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,description,thumbnail,date,created_at,updated_at")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                eventModel.created_at = DateTime.Now;
                eventModel.updated_at = DateTime.Now;

                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // GET: AdminEventModel/Edit/5
        // [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Event.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // POST: AdminEventModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,description,thumbnail,date,created_at,updated_at")] EventModel eventModel)
        {
            if (id != eventModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingEvent = await _context.Event.AsNoTracking().FirstOrDefaultAsync(e => e.id == id);

                    if (existingEvent != null)
                    {
                        eventModel.created_at = existingEvent.created_at;
                    }

                    eventModel.updated_at = DateTime.Now;

                    _context.Update(eventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventModelExists(eventModel.id))
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
            return View(eventModel);
        }

        // GET: AdminEventModel/Delete/5
        // [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Event
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // POST: AdminEventModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventModel = await _context.Event.FindAsync(id);
            if (eventModel != null)
            {
                _context.Event.Remove(eventModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventModelExists(int id)
        {
            return _context.Event.Any(e => e.id == id);
        }
    }
}
