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
    // [Route("admin/types")]
    public class AdminTypeModelController : Controller
    {
        private readonly LaCrouteContext _context;

        public AdminTypeModelController(LaCrouteContext context)
        {
            _context = context;
        }

        // GET: AdminTypeModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Type.ToListAsync());
        }

        // GET: AdminTypeModel/Details/5
        [Route("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeModel = await _context.Type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeModel == null)
            {
                return NotFound();
            }

            return View(typeModel);
        }

        // GET: AdminTypeModel/Create
        // [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminTypeModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Created_at,Updated_at")] TypeModel typeModel)
        {
            if (ModelState.IsValid)
            {
                typeModel.Created_at = DateTime.Now;
                typeModel.Updated_at = DateTime.Now;

                _context.Add(typeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeModel);
        }

        // GET: AdminTypeModel/Edit/5
        // [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeModel = await _context.Type.FindAsync(id);
            if (typeModel == null)
            {
                return NotFound();
            }
            return View(typeModel);
        }

        // POST: AdminTypeModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Created_at,Updated_at")] TypeModel typeModel)
        {
            if (id != typeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingType = await _context.Type.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

                    if (existingType != null)
                    {
                        typeModel.Created_at = existingType.Created_at;
                    }

                    typeModel.Updated_at = DateTime.Now;

                    _context.Update(typeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeModelExists(typeModel.Id))
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
            return View(typeModel);
        }

        // GET: AdminTypeModel/Delete/5
        // [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeModel = await _context.Type
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeModel == null)
            {
                return NotFound();
            }

            return View(typeModel);
        }

        // POST: AdminTypeModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeModel = await _context.Type.FindAsync(id);
            if (typeModel != null)
            {
                _context.Type.Remove(typeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeModelExists(int id)
        {
            return _context.Type.Any(e => e.Id == id);
        }
    }
}
