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
    public class GoodsTypesController : Controller
    {
        private readonly GoodsPackagingContext _context;

        public GoodsTypesController(GoodsPackagingContext context)
        {
            _context = context;
        }

        // GET: GoodsTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoodsType.ToListAsync());
        }

        // GET: GoodsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsType = await _context.GoodsType
                .FirstOrDefaultAsync(m => m.GoodsTypeId == id);
            if (goodsType == null)
            {
                return NotFound();
            }

            return View(goodsType);
        }

        // GET: GoodsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodsTypeId,GoodType,Description")] GoodsType goodsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsType);
        }

        // GET: GoodsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsType = await _context.GoodsType.FindAsync(id);
            if (goodsType == null)
            {
                return NotFound();
            }
            return View(goodsType);
        }

        // POST: GoodsTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodsTypeId,GoodType,Description")] GoodsType goodsType)
        {
            if (id != goodsType.GoodsTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsTypeExists(goodsType.GoodsTypeId))
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
            return View(goodsType);
        }

        // GET: GoodsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsType = await _context.GoodsType
                .FirstOrDefaultAsync(m => m.GoodsTypeId == id);
            if (goodsType == null)
            {
                return NotFound();
            }

            return View(goodsType);
        }

        // POST: GoodsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsType = await _context.GoodsType.FindAsync(id);
            _context.GoodsType.Remove(goodsType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsTypeExists(int id)
        {
            return _context.GoodsType.Any(e => e.GoodsTypeId == id);
        }
    }
}
