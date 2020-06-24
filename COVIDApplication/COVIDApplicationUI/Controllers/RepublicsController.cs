using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure_;
using Application.Commands.Republics.Queries.GetAllRepublics;

namespace COVIDApplicationUI.Controllers
{
    public class RepublicsController : BaseController
    {
        private readonly AppDBContext _context;

        public RepublicsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Republics
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetRepublicsListQuery()));
        }

        // GET: Republics/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var republic = await _context.Republics
                .FirstOrDefaultAsync(m => m.Title == id);
            if (republic == null)
            {
                return NotFound();
            }

            return View(republic);
        }

        // GET: Republics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Republics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Population,Square")] Republic republic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(republic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(republic);
        }

        // GET: Republics/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var republic = await _context.Republics.FindAsync(id);
            if (republic == null)
            {
                return NotFound();
            }
            return View(republic);
        }

        // POST: Republics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Title,Population,Square")] Republic republic)
        {
            if (id != republic.Title)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(republic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepublicExists(republic.Title))
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
            return View(republic);
        }

        // GET: Republics/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var republic = await _context.Republics
                .FirstOrDefaultAsync(m => m.Title == id);
            if (republic == null)
            {
                return NotFound();
            }

            return View(republic);
        }

        // POST: Republics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var republic = await _context.Republics.FindAsync(id);
            _context.Republics.Remove(republic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepublicExists(string id)
        {
            return _context.Republics.Any(e => e.Title == id);
        }
    }
}
