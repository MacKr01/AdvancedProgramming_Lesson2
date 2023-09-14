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
    public class NarzedziasController : Controller
    {
        private readonly MvcNarzedziaContext _context;

        public NarzedziasController(MvcNarzedziaContext context)
        {
            _context = context;
        }

        // GET: Narzedzias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Narzedzia.ToListAsync());
        }

        // GET: Narzedzias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narzedzia = await _context.Narzedzia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (narzedzia == null)
            {
                return NotFound();
            }

            return View(narzedzia);
        }

        // GET: Narzedzias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Narzedzias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Typ_narzedzia,Material_wykonania,Waga,Dlugosc,Cena")] Narzedzia narzedzia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narzedzia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(narzedzia);
        }

        // GET: Narzedzias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narzedzia = await _context.Narzedzia.FindAsync(id);
            if (narzedzia == null)
            {
                return NotFound();
            }
            return View(narzedzia);
        }

        // POST: Narzedzias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Typ_narzedzia,Material_wykonania,Waga,Dlugosc,Cena")] Narzedzia narzedzia)
        {
            if (id != narzedzia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narzedzia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarzedziaExists(narzedzia.Id))
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
            return View(narzedzia);
        }

        // GET: Narzedzias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narzedzia = await _context.Narzedzia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (narzedzia == null)
            {
                return NotFound();
            }

            return View(narzedzia);
        }

        // POST: Narzedzias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var narzedzia = await _context.Narzedzia.FindAsync(id);
            _context.Narzedzia.Remove(narzedzia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarzedziaExists(int id)
        {
            return _context.Narzedzia.Any(e => e.Id == id);
        }
    }
}
