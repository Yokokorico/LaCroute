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
    [Route("admin/products-labels")]
    public class AdminProductLabelModelController : Controller
    {
        private readonly LaCrouteContext _context;

        public AdminProductLabelModelController(LaCrouteContext context)
        {
            _context = context;
        }

        // GET: AdminProductLabelModel
        public async Task<IActionResult> Index()
        {
            var laCrouteContext = _context.ProductLabel.Include(p => p.Label).Include(p => p.Product);
            return View(await laCrouteContext.ToListAsync());
        }

        // GET: AdminProductLabelModel/Details/5
        [Route("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLabelModel = await _context.ProductLabel
                .Include(p => p.Label)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productLabelModel == null)
            {
                return NotFound();
            }

            return View(productLabelModel);
        }

        // GET: AdminProductLabelModel/Create
        [Route("create")]
        public IActionResult Create()
        {
            ViewData["LabelId"] = new SelectList(_context.Label, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: AdminProductLabelModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,LabelId")] ProductLabelModel productLabelModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productLabelModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabelId"] = new SelectList(_context.Label, "Id", "Id", productLabelModel.LabelId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productLabelModel.ProductId);
            return View(productLabelModel);
        }

        // GET: AdminProductLabelModel/Edit/5
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLabelModel = await _context.ProductLabel.FindAsync(id);
            if (productLabelModel == null)
            {
                return NotFound();
            }
            ViewData["LabelId"] = new SelectList(_context.Label, "Id", "Id", productLabelModel.LabelId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productLabelModel.ProductId);
            return View(productLabelModel);
        }

        // POST: AdminProductLabelModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,LabelId")] ProductLabelModel productLabelModel)
        {
            if (id != productLabelModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productLabelModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductLabelModelExists(productLabelModel.Id))
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
            ViewData["LabelId"] = new SelectList(_context.Label, "Id", "Id", productLabelModel.LabelId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", productLabelModel.ProductId);
            return View(productLabelModel);
        }

        // GET: AdminProductLabelModel/Delete/5
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productLabelModel = await _context.ProductLabel
                .Include(p => p.Label)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productLabelModel == null)
            {
                return NotFound();
            }

            return View(productLabelModel);
        }

        // POST: AdminProductLabelModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productLabelModel = await _context.ProductLabel.FindAsync(id);
            if (productLabelModel != null)
            {
                _context.ProductLabel.Remove(productLabelModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductLabelModelExists(int id)
        {
            return _context.ProductLabel.Any(e => e.Id == id);
        }
    }
}
