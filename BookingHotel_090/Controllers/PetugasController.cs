using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingHotel_090.Models;

namespace BookingHotel_090.Controllers
{
    public class PetugasController : Controller
    {
        private readonly BookingHotelContext _context;

        public PetugasController(BookingHotelContext context)
        {
            _context = context;
        }

        // GET: Petugas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Petugas.ToListAsync());
        }

        // GET: Petugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petuga = await _context.Petugas
                .FirstOrDefaultAsync(m => m.IdPetugas == id);
            if (petuga == null)
            {
                return NotFound();
            }

            return View(petuga);
        }

        // GET: Petugas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Petugas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPetugas,NamaPetugas")] Petuga petuga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petuga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petuga);
        }

        // GET: Petugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petuga = await _context.Petugas.FindAsync(id);
            if (petuga == null)
            {
                return NotFound();
            }
            return View(petuga);
        }

        // POST: Petugas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPetugas,NamaPetugas")] Petuga petuga)
        {
            if (id != petuga.IdPetugas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petuga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetugaExists(petuga.IdPetugas))
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
            return View(petuga);
        }

        // GET: Petugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petuga = await _context.Petugas
                .FirstOrDefaultAsync(m => m.IdPetugas == id);
            if (petuga == null)
            {
                return NotFound();
            }

            return View(petuga);
        }

        // POST: Petugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petuga = await _context.Petugas.FindAsync(id);
            _context.Petugas.Remove(petuga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetugaExists(int id)
        {
            return _context.Petugas.Any(e => e.IdPetugas == id);
        }
    }
}
