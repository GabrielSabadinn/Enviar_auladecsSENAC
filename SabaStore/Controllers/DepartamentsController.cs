﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SabaStore.Data;
using SabaStore.Models;

namespace SabaStore.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly SabaStoreContext _context;

        public DepartamentsController(SabaStoreContext context)
        {
            _context = context;
        }

        // GET: Departaments
        public async Task<IActionResult> Index()
        {
              return _context.Departament != null ? 
                          View(await _context.Departament.ToListAsync()) :
                          Problem("Entity set 'SabaStoreContext.Departament'  is null.");
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] Departament departament)
        {
            if (id != departament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentExists(departament.Id))
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
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Departament == null)
            {
                return Problem("Entity set 'SabaStoreContext.Departament'  is null.");
            }
            var departament = await _context.Departament.FindAsync(id);
            if (departament != null)
            {
                _context.Departament.Remove(departament);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentExists(string id)
        {
          return (_context.Departament?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
