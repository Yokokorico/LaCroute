using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCroute.Data;
using LaCroute.Models;

namespace LaCroute
{
    public class AdminLabelModelController : Controller
    {
        private readonly LaCrouteContext _context;

        public AdminLabelModelController(LaCrouteContext context)
        {
            _context = context;
        }

        // GET: AdminLabelModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Label.ToListAsync());
        }

        // GET: AdminLabelModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.Label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelModel == null)
            {
                return NotFound();
            }

            return View(labelModel);
        }

        // GET: AdminLabelModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminLabelModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Svg,Created_at,Updated_at")] LabelModel labelModel)
        {
            if (ModelState.IsValid)
            {
                labelModel.Created_at = DateTime.Now;
                labelModel.Updated_at = DateTime.Now;

                _context.Add(labelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labelModel);
        }

        // GET: AdminLabelModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.Label.FindAsync(id);
            if (labelModel == null)
            {
                return NotFound();
            }
            return View(labelModel);
        }

        // POST: AdminLabelModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Svg,Created_at,Updated_at")] LabelModel labelModel)
        {
            if (id != labelModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingLabel = await _context.Label.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);

                    if (existingLabel != null)
                    {
                        labelModel.Created_at = existingLabel.Created_at;
                    }

                    labelModel.Updated_at = DateTime.Now;

                    _context.Update(labelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelModelExists(labelModel.Id))
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
            return View(labelModel);
        }

        // GET: AdminLabelModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labelModel = await _context.Label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labelModel == null)
            {
                return NotFound();
            }

            return View(labelModel);
        }

        // POST: AdminLabelModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labelModel = await _context.Label.FindAsync(id);
            if (labelModel != null)
            {
                _context.Label.Remove(labelModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelModelExists(int id)
        {
            return _context.Label.Any(e => e.Id == id);
        }
    }
}
