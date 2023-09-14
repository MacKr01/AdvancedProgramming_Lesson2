using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedProgramming_Lesson1.Data;
using AdvancedProgramming_Lesson1.Models;

namespace AdvancedProgramming_Lesson1.Controllers
{
    public class WarzywasController : Controller
    {
        private readonly MvcWarzywaContext _context;

        public WarzywasController(MvcWarzywaContext context)
        {
            _context = context;
        }

        // GET: Warzywas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Warzywa.ToListAsync());
        }

        // GET: Warzywas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warzywa = await _context.Warzywa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warzywa == null)
            {
                return NotFound();
            }

            return View(warzywa);
        }

        // GET: Warzywas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Warzywas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Typ_warzywa,Data_siewu,Data_zbioru,Waga,Cena")] Warzywa warzywa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warzywa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warzywa);
        }

        // GET: Warzywas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warzywa = await _context.Warzywa.FindAsync(id);
            if (warzywa == null)
            {
                return NotFound();
            }
            return View(warzywa);
        }

        // POST: Warzywas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Typ_warzywa,Data_siewu,Data_zbioru,Waga,Cena")] Warzywa warzywa)
        {
            if (id != warzywa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warzywa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarzywaExists(warzywa.Id))
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
            return View(warzywa);
        }

        // GET: Warzywas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warzywa = await _context.Warzywa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warzywa == null)
            {
                return NotFound();
            }

            return View(warzywa);
        }

        // POST: Warzywas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warzywa = await _context.Warzywa.FindAsync(id);
            _context.Warzywa.Remove(warzywa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarzywaExists(int id)
        {
            return _context.Warzywa.Any(e => e.Id == id);
        }
    }
}
