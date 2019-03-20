using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RewardRecycle.Data;
using RewardRecycle.Models;

namespace RewardRecycle.Controllers
{
    public class RewardModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RewardModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RewardModel
        // Help tag to make sure someone is logged on when he starts shopping for items
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.RewardModel.ToListAsync());
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardModel = await _context.RewardModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewardModel == null)
            {
                return NotFound();
            }

            return View(rewardModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RewardModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ImTheAdmin")]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Description,ImagePath")] RewardModel rewardModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rewardModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewardModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardModel = await _context.RewardModel.FindAsync(id);
            if (rewardModel == null)
            {
                return NotFound();
            }
            return View(rewardModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // POST: RewardModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,Description,ImagePath")] RewardModel rewardModel)
        {
            if (id != rewardModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardModelExists(rewardModel.Id))
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
            return View(rewardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardModel = await _context.RewardModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewardModel == null)
            {
                return NotFound();
            }
            return View(rewardModel);
        }

        [Authorize(Policy = "ImTheAdmin")]
        // POST: RewardModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rewardModel = await _context.RewardModel.FindAsync(id);
            _context.RewardModel.Remove(rewardModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Order(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardModel = await _context.RewardModel
                .FirstOrDefaultAsync(m => m.Id == id);

            if (rewardModel == null)
            {
                return NotFound();
            }

            return RedirectToAction("Create", "RewardOrderModel", new { id });
        }

        private bool RewardModelExists(int id)
        {
            return _context.RewardModel.Any(e => e.Id == id);
        }
        [Authorize(Policy = "ImTheAdmin")]
        public async Task<IActionResult> OrderOverview()
        {
            return RedirectToAction("Index", "RewardOrderModel");
        }
        /**/
    }
}
