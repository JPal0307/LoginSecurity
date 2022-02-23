using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
    public class SecurityController : Controller
    {
        private readonly SecurityContext _context;

        public SecurityController(SecurityContext context)
        {
            _context = context;
        }

        // GET: Security
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Security/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var securityModel = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (securityModel == null)
            {
                return NotFound();
            }

            return View(securityModel);
        }

        // GET: Security/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Security/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Lastname")] SecurityModel securityModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(securityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(securityModel);
        }

        // GET: Security/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var securityModel = await _context.Contacts.FindAsync(id);
            if (securityModel == null)
            {
                return NotFound();
            }
            return View(securityModel);
        }

        // POST: Security/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Lastname")] SecurityModel securityModel)
        {
            if (id != securityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(securityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecurityModelExists(securityModel.Id))
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
            return View(securityModel);
        }

        // GET: Security/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var securityModel = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (securityModel == null)
            {
                return NotFound();
            }

            return View(securityModel);
        }

        // POST: Security/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var securityModel = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(securityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecurityModelExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
