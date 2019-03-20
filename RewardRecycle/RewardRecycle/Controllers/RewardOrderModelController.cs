using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RewardRecycle.Data;
using RewardRecycle.Models;

namespace RewardRecycle.Controllers
{
    public class RewardOrderModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUserModel> _userManager;

        public RewardOrderModelController(ApplicationDbContext context, UserManager<ApplicationUserModel> userManager)
        {
            _context = context;

            _userManager = userManager;
        }
        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardOrderModel
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RewardOrderModel.Include(r => r.RewardModel);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardOrderModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardOrderModel = await _context.RewardOrderModel
                .Include(r => r.RewardModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewardOrderModel == null)
            {
                return NotFound();
            }

            return View(rewardOrderModel);
        }

        // GET: RewardOrderModel/Create
        public IActionResult Create(int id)
        {
            ViewData["RewardModelId"] = new SelectList(_context.RewardModel, "Id", "Id");
            return View();
        }

        // POST: RewardOrderModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,StreetName,HouseNumber,PostalCode")] RewardOrderModel rewardOrderModel, int id)
        {
            var user = await _userManager.GetUserAsync(User);
            
            var rewardModel = await _context.RewardModel.FindAsync(id);

            if(user.Points >= rewardModel.Price)
            {
                user.Points -= rewardModel.Price;
                if (ModelState.IsValid)
                {
                    rewardOrderModel.RewardModel = rewardModel;
                    rewardOrderModel.Datum = DateTime.Now;
                    _context.Add(rewardOrderModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "RewardModel", "succes");
                }
            }
           
            ViewData["RewardModelId"] = new SelectList(_context.RewardModel, "Id", "Id", rewardOrderModel.RewardModelId);
            return View(rewardOrderModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardOrderModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardOrderModel = await _context.RewardOrderModel.FindAsync(id);
            if (rewardOrderModel == null)
            {
                return NotFound();
            }
            ViewData["RewardModelId"] = new SelectList(_context.RewardModel, "Id", "Id", rewardOrderModel.RewardModelId);
            return View(rewardOrderModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // POST: RewardOrderModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StreetName,HouseNumber,PostalCode,Datum,RewardModelId")] RewardOrderModel rewardOrderModel)
        {
            if (id != rewardOrderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardOrderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardOrderModelExists(rewardOrderModel.Id))
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
            ViewData["RewardModelId"] = new SelectList(_context.RewardModel, "Id", "Id", rewardOrderModel.RewardModelId);
            return View(rewardOrderModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // GET: RewardOrderModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardOrderModel = await _context.RewardOrderModel
                .Include(r => r.RewardModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewardOrderModel == null)
            {
                return NotFound();
            }

            return View(rewardOrderModel);
        }
        [Authorize(Policy = "ImTheAdmin")]
        // POST: RewardOrderModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rewardOrderModel = await _context.RewardOrderModel.FindAsync(id);
            _context.RewardOrderModel.Remove(rewardOrderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RewardOrderModelExists(int id)
        {
            return _context.RewardOrderModel.Any(e => e.Id == id);
        }

        public async Task<IActionResult> RewardOverview()
        {
            return RedirectToAction("Index", "RewardModel");
        }
    }
}
