using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoSimulation.Data;
using CryptoSimulation.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CryptoSimulation.Controllers
{
    public class WalletPartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public WalletPartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: WalletPart
        public async Task<IActionResult> Index()
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            
            var applicationDbContext = _context.WalletPart.Include(w => w.Wallet).Where(i => i.WalletID == currentUser.WalletID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WalletPart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walletPart = await _context.WalletPart
                .Include(w => w.Wallet)
                .FirstOrDefaultAsync(m => m.WalletPartID == id);
            if (walletPart == null)
            {
                return NotFound();
            }

            return View(walletPart);
        }

        // GET: WalletPart/Create
        public IActionResult Create()
        {
            ViewData["WalletID"] = new SelectList(_context.Wallet, "ID", "ID");
            return View();
        }

        // POST: WalletPart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WalletPartID,WalletID,Currency,Amount")] WalletPart walletPart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(walletPart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WalletID"] = new SelectList(_context.Wallet, "ID", "ID", walletPart.WalletID);
            return View(walletPart);
        }

        // GET: WalletPart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walletPart = await _context.WalletPart.FindAsync(id);
            if (walletPart == null)
            {
                return NotFound();
            }
            ViewData["WalletID"] = new SelectList(_context.Wallet, "ID", "ID", walletPart.WalletID);
            return View(walletPart);
        }

        // POST: WalletPart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WalletPartID,WalletID,Currency,Amount")] WalletPart walletPart)
        {
            if (id != walletPart.WalletPartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(walletPart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletPartExists(walletPart.WalletPartID))
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
            ViewData["WalletID"] = new SelectList(_context.Wallet, "ID", "ID", walletPart.WalletID);
            return View(walletPart);
        }

        // GET: WalletPart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var walletPart = await _context.WalletPart
                .Include(w => w.Wallet)
                .FirstOrDefaultAsync(m => m.WalletPartID == id);
            if (walletPart == null)
            {
                return NotFound();
            }

            return View(walletPart);
        }

        // POST: WalletPart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var walletPart = await _context.WalletPart.FindAsync(id);
            _context.WalletPart.Remove(walletPart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalletPartExists(int id)
        {
            return _context.WalletPart.Any(e => e.WalletPartID == id);
        }
    }
}
