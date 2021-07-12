using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoSimulation.Data;
using CryptoSimulation.Models;

namespace CryptoSimulation.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transaction.Include(t => t.Portfolio).Include(t => t.WalletReciever).Include(t => t.WalletSender);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Portfolio)
                .Include(t => t.WalletReciever)
                .Include(t => t.WalletSender)
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            ViewData["PortfolioID"] = new SelectList(_context.Portfolio, "PortfolioID", "PortfolioID");
            ViewData["WalletIDReciever"] = new SelectList(_context.Wallet, "ID", "ID");
            ViewData["WalletIDSender"] = new SelectList(_context.Wallet, "ID", "ID");
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionID,WalletIDSender,WalletIDReciever,PortfolioID,Currency,Value,TransactionDate")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PortfolioID"] = new SelectList(_context.Portfolio, "PortfolioID", "PortfolioID", transaction.PortfolioID);
            ViewData["WalletIDReciever"] = new SelectList(_context.Wallet, "ID", "ID", transaction.WalletIDReciever);
            ViewData["WalletIDSender"] = new SelectList(_context.Wallet, "ID", "ID", transaction.WalletIDSender);
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["PortfolioID"] = new SelectList(_context.Portfolio, "PortfolioID", "PortfolioID", transaction.PortfolioID);
            ViewData["WalletIDReciever"] = new SelectList(_context.Wallet, "ID", "ID", transaction.WalletIDReciever);
            ViewData["WalletIDSender"] = new SelectList(_context.Wallet, "ID", "ID", transaction.WalletIDSender);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionID,WalletIDSender,WalletIDReciever,PortfolioID,Currency,Value,TransactionDate")] Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionID))
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
            ViewData["PortfolioID"] = new SelectList(_context.Portfolio, "PortfolioID", "PortfolioID", transaction.PortfolioID);
            ViewData["WalletIDReciever"] = new SelectList(_context.Wallet, "ID", "ID", transaction.WalletIDReciever);
            ViewData["WalletIDSender"] = new SelectList(_context.Wallet, "ID", "ID", transaction.WalletIDSender);
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Portfolio)
                .Include(t => t.WalletReciever)
                .Include(t => t.WalletSender)
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionID == id);
        }
    }
}
