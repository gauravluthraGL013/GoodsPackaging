using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodsPackaging.Data;
using GoodsPackaging.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoodsPackaging.Controllers
{
    [Authorize]
    public class PackageTypesController : Controller
    {
        private readonly GoodsPackagingContext _context;

        public PackageTypesController(GoodsPackagingContext context)
        {
            _context = context;
        }

        // GET: PackageTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackageType.ToListAsync());
        }

        // GET: PackageTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageType
                .FirstOrDefaultAsync(m => m.PackageTypeId == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // GET: PackageTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageTypeId,PackagingType,Description")] PackageType packageType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(packageType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(packageType);
        }

        // GET: PackageTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageType.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }
            return View(packageType);
        }

        // POST: PackageTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageTypeId,PackagingType,Description")] PackageType packageType)
        {
            if (id != packageType.PackageTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(packageType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageTypeExists(packageType.PackageTypeId))
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
            return View(packageType);
        }

        // GET: PackageTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageType
                .FirstOrDefaultAsync(m => m.PackageTypeId == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // POST: PackageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var packageType = await _context.PackageType.FindAsync(id);
            _context.PackageType.Remove(packageType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageTypeExists(int id)
        {
            return _context.PackageType.Any(e => e.PackageTypeId == id);
        }
    }
}
