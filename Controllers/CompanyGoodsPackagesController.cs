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
    public class CompanyGoodsPackagesController : Controller
    {
        private readonly GoodsPackagingContext _context;

        public CompanyGoodsPackagesController(GoodsPackagingContext context)
        {
            _context = context;
        }

        // GET: CompanyGoodsPackages
        public async Task<IActionResult> Index()
        {
            var goodsPackagingContext = _context.CompanyGoodsPackage.Include(c => c.Company).Include(c => c.GoodsType).Include(c => c.PackageType);
            return View(await goodsPackagingContext.ToListAsync());
        }

        // GET: CompanyGoodsPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyGoodsPackage = await _context.CompanyGoodsPackage
                .Include(c => c.Company)
                .Include(c => c.GoodsType)
                .Include(c => c.PackageType)
                .FirstOrDefaultAsync(m => m.companyGoodsPackageId == id);
            if (companyGoodsPackage == null)
            {
                return NotFound();
            }

            return View(companyGoodsPackage);
        }

        // GET: CompanyGoodsPackages/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId");
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsType, "GoodsTypeId", "GoodsTypeId");
            ViewData["PackageTypeid"] = new SelectList(_context.PackageType, "PackageTypeId", "PackageTypeId");
            return View();
        }

        // POST: CompanyGoodsPackages/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("companyGoodsPackageId,CompanyId,PackageTypeid,GoodsTypeId,PackagingDate")] CompanyGoodsPackage companyGoodsPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyGoodsPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", companyGoodsPackage.CompanyId);
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsType, "GoodsTypeId", "GoodsTypeId", companyGoodsPackage.GoodsTypeId);
            ViewData["PackageTypeid"] = new SelectList(_context.PackageType, "PackageTypeId", "PackageTypeId", companyGoodsPackage.PackageTypeid);
            return View(companyGoodsPackage);
        }

        // GET: CompanyGoodsPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyGoodsPackage = await _context.CompanyGoodsPackage.FindAsync(id);
            if (companyGoodsPackage == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", companyGoodsPackage.CompanyId);
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsType, "GoodsTypeId", "GoodsTypeId", companyGoodsPackage.GoodsTypeId);
            ViewData["PackageTypeid"] = new SelectList(_context.PackageType, "PackageTypeId", "PackageTypeId", companyGoodsPackage.PackageTypeid);
            return View(companyGoodsPackage);
        }

        // POST: CompanyGoodsPackages/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("companyGoodsPackageId,CompanyId,PackageTypeid,GoodsTypeId,PackagingDate")] CompanyGoodsPackage companyGoodsPackage)
        {
            if (id != companyGoodsPackage.companyGoodsPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyGoodsPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyGoodsPackageExists(companyGoodsPackage.companyGoodsPackageId))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", companyGoodsPackage.CompanyId);
            ViewData["GoodsTypeId"] = new SelectList(_context.GoodsType, "GoodsTypeId", "GoodsTypeId", companyGoodsPackage.GoodsTypeId);
            ViewData["PackageTypeid"] = new SelectList(_context.PackageType, "PackageTypeId", "PackageTypeId", companyGoodsPackage.PackageTypeid);
            return View(companyGoodsPackage);
        }

        // GET: CompanyGoodsPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyGoodsPackage = await _context.CompanyGoodsPackage
                .Include(c => c.Company)
                .Include(c => c.GoodsType)
                .Include(c => c.PackageType)
                .FirstOrDefaultAsync(m => m.companyGoodsPackageId == id);
            if (companyGoodsPackage == null)
            {
                return NotFound();
            }

            return View(companyGoodsPackage);
        }

        // POST: CompanyGoodsPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyGoodsPackage = await _context.CompanyGoodsPackage.FindAsync(id);
            _context.CompanyGoodsPackage.Remove(companyGoodsPackage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyGoodsPackageExists(int id)
        {
            return _context.CompanyGoodsPackage.Any(e => e.companyGoodsPackageId == id);
        }
    }
}
