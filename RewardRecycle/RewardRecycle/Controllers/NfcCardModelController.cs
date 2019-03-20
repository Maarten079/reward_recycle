using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RewardRecycle.Data;
using RewardRecycle.Models;
using Microsoft.AspNetCore.Authorization;

namespace RewardRecycle.Controllers
{
    public class NfcCardModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NfcCardModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: NfcCardModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NfcCardModel.Include(n => n.ApplicationUserModel);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: NfcCardModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nfcCardModel = await _context.NfcCardModel
                .Include(n => n.ApplicationUserModel)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (nfcCardModel == null)
            {
                return NotFound();
            }

            return View(nfcCardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: NfcCardModel/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserModelId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        [Authorize(Policy = "ImTheAdmin")]
        // POST: NfcCardModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,ApplicationUserModelId,LastScanDate")] NfcCardModel nfcCardModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nfcCardModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserModelId"] = new SelectList(_context.Users, "Id", "Id", nfcCardModel.ApplicationUserModelId);
            return View(nfcCardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: NfcCardModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nfcCardModel = await _context.NfcCardModel.FindAsync(id);
            if (nfcCardModel == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserModelId"] = new SelectList(_context.Users, "Id", "Id", nfcCardModel.ApplicationUserModelId);
            return View(nfcCardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // POST: NfcCardModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardId,ApplicationUserModelId,LastScanDate")] NfcCardModel nfcCardModel)
        {
            if (id != nfcCardModel.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nfcCardModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NfcCardModelExists(nfcCardModel.CardId))
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
            ViewData["ApplicationUserModelId"] = new SelectList(_context.Users, "Id", "Id", nfcCardModel.ApplicationUserModelId);
            return View(nfcCardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: NfcCardModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nfcCardModel = await _context.NfcCardModel
                .Include(n => n.ApplicationUserModel)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (nfcCardModel == null)
            {
                return NotFound();
            }

            return View(nfcCardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // POST: NfcCardModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nfcCardModel = await _context.NfcCardModel.FindAsync(id);
            _context.NfcCardModel.Remove(nfcCardModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NfcCardModelExists(int id)
        {
            return _context.NfcCardModel.Any(e => e.CardId == id);
        }
    }
}
