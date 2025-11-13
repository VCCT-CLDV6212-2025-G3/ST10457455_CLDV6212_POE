using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABC_Retail_CloudApp.Data;
using ABC_Retail_CloudApp.Models;

namespace ABC_Retail_CloudApp.Controllers
{
    public class ProductSQLController : Controller
    {
        private readonly SQLDbContext _context;

        public ProductSQLController(SQLDbContext context)
        {
            _context = context;
        }

        // GET: ProductSQL
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsSQL.ToListAsync());
        }

        // GET: ProductSQL/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSQL = await _context.ProductsSQL
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productSQL == null)
            {
                return NotFound();
            }

            return View(productSQL);
        }

        // GET: ProductSQL/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductSQL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Category,Price,ImageUrl")] ProductSQL productSQL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSQL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSQL);
        }

        // GET: ProductSQL/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSQL = await _context.ProductsSQL.FindAsync(id);
            if (productSQL == null)
            {
                return NotFound();
            }
            return View(productSQL);
        }

        // POST: ProductSQL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Category,Price,ImageUrl")] ProductSQL productSQL)
        {
            if (id != productSQL.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSQL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSQLExists(productSQL.ProductId))
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
            return View(productSQL);
        }

        // GET: ProductSQL/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSQL = await _context.ProductsSQL
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productSQL == null)
            {
                return NotFound();
            }

            return View(productSQL);
        }

        // POST: ProductSQL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSQL = await _context.ProductsSQL.FindAsync(id);
            if (productSQL != null)
            {
                _context.ProductsSQL.Remove(productSQL);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSQLExists(int id)
        {
            return _context.ProductsSQL.Any(e => e.ProductId == id);
        }
    }
}
