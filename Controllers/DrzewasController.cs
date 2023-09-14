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
    public class DrzewasController : Controller
    {
        private readonly MvcDrzewaContext _context;

        public DrzewasController(MvcDrzewaContext context)
        {
            _context = context;
        }

        // GET: Drzewas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drzewa.ToListAsync());
        }

        // GET: Drzewas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drzewa = await _context.Drzewa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drzewa == null)
            {
                return NotFound();
            }

            return View(drzewa);
        }

        // GET: Drzewas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drzewas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Wysokosc,Rodzaj,Data_posadzenia,Srednica_pnia,Kolor_lisci")] Drzewa drzewa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drzewa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drzewa);
        }

        // GET: Drzewas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drzewa = await _context.Drzewa.FindAsync(id);
            if (drzewa == null)
            {
                return NotFound();
            }
            return View(drzewa);
        }

        // POST: Drzewas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Wysokosc,Rodzaj,Data_posadzenia,Srednica_pnia,Kolor_lisci")] Drzewa drzewa)
        {
            if (id != drzewa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drzewa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrzewaExists(drzewa.Id))
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
            return View(drzewa);
        }

        // GET: Drzewas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drzewa = await _context.Drzewa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drzewa == null)
            {
                return NotFound();
            }

            return View(drzewa);
        }

        // POST: Drzewas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drzewa = await _context.Drzewa.FindAsync(id);
            _context.Drzewa.Remove(drzewa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrzewaExists(int id)
        {
            return _context.Drzewa.Any(e => e.Id == id);
        }
    }
}
