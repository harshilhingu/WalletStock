using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WalletStock.Data;
using WalletStock.Models;

namespace WalletStock.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletStockContext _context;

        public WalletController(WalletStockContext context)
        {
            _context = context;
        }

        // GET: Wallet
        public async Task<IActionResult> Index(string searchString)
        {
            var Wallets = from m in _context.Wallets
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Wallets = Wallets.Where(s => s.Company.Contains(searchString));
            }

            return View(await Wallets.ToListAsync());
        }

        // GET: Wallet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallets = await _context.Wallets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallets == null)
            {
                return NotFound();
            }

            return View(wallets);
        }

        // GET: Wallet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wallet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company,Color,Leather,Shape,Price")] Wallets wallets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wallets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wallets);
        }

        // GET: Wallet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallets = await _context.Wallets.FindAsync(id);
            if (wallets == null)
            {
                return NotFound();
            }
            return View(wallets);
        }

        // POST: Wallet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Company,Color,Leather,Shape,Price")] Wallets wallets)
        {
            if (id != wallets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wallets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletsExists(wallets.Id))
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
            return View(wallets);
        }

        // GET: Wallet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallets = await _context.Wallets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallets == null)
            {
                return NotFound();
            }

            return View(wallets);
        }

        // POST: Wallet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wallets = await _context.Wallets.FindAsync(id);
            _context.Wallets.Remove(wallets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalletsExists(int id)
        {
            return _context.Wallets.Any(e => e.Id == id);
        }
    }
}
