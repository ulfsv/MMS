using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMS.Data;
using MMS.Models;

namespace MMS.Controllers
{
    public class MachinesController : Controller
    {
        private readonly MMSContext _context;

        public MachinesController(MMSContext context)
        {
            _context = context;
        }

        // GET: Machines
        public async Task<IActionResult> Index()
        {
            return View(await _context.MMS.ToListAsync());
        }

        // GET: Machines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machines = await _context.MMS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machines == null)
            {
                return NotFound();
            }

            return View(machines);
        }

        // GET: Machines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Machines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Data,Status")] Machines machines)
        {
            if (ModelState.IsValid)
            {
                machines.Id = Guid.NewGuid();
                _context.Add(machines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machines);
        }

        // GET: Machines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machines = await _context.MMS.FindAsync(id);
            if (machines == null)
            {
                return NotFound();
            }
            return View(machines);
        }

        // POST: Machines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Data,Status")] Machines machines)
        {
            if (id != machines.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachinesExists(machines.Id))
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
            return View(machines);
        }

        // GET: Machines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machines = await _context.MMS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (machines == null)
            {
                return NotFound();
            }

            return View(machines);
        }

        // POST: Machines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var machines = await _context.MMS.FindAsync(id);
            _context.MMS.Remove(machines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachinesExists(Guid id)
        {
            return _context.MMS.Any(e => e.Id == id);
        }
    }
}
