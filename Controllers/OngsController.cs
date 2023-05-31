using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PataAmiga.Data;
using PataAmiga.Models.Domain;

namespace PataAmiga.Controllers
{
    public class OngsController : Controller
    {
        private readonly PataAmigaDbContext _context;

        public OngsController(PataAmigaDbContext context)
        {
            _context = context;
        }

        // GET: Ongs
        public async Task<IActionResult> Index()
        {
              return _context.Ongs != null ? 
                          View(await _context.Ongs.ToListAsync()) :
                          Problem("Entity set 'PataAmigaDbContext.Ongs'  is null.");
        }

        // GET: Ongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ongs == null)
            {
                return NotFound();
            }

            var ong = await _context.Ongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // GET: Ongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Objetivo,Telefone,Email")] Ong ong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ong);
        }

        // GET: Ongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ongs == null)
            {
                return NotFound();
            }

            var ong = await _context.Ongs.FindAsync(id);
            if (ong == null)
            {
                return NotFound();
            }
            return View(ong);
        }

        // POST: Ongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Objetivo,Telefone,Email")] Ong ong)
        {
            if (id != ong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OngExists(ong.Id))
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
            return View(ong);
        }

        // GET: Ongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ongs == null)
            {
                return NotFound();
            }

            var ong = await _context.Ongs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ong == null)
            {
                return NotFound();
            }

            return View(ong);
        }

        // POST: Ongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ongs == null)
            {
                return Problem("Entity set 'PataAmigaDbContext.Ongs'  is null.");
            }
            var ong = await _context.Ongs.FindAsync(id);
            if (ong != null)
            {
                _context.Ongs.Remove(ong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OngExists(int id)
        {
          return (_context.Ongs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
