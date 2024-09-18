using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTHUVIEN.Models;

namespace QLTHUVIEN.Controllers
{
    public class SachesController : Controller
    {
        private readonly QltvContext _context;

        public SachesController(QltvContext context)
        {
            _context = context;
        }

        // GET: Saches
        public async Task<IActionResult> Index()
        {
            var qltvContext = _context.Saches.Include(s => s.MaNxbNavigation).Include(s => s.MaTacGiaNavigation);
            return View(await qltvContext.ToListAsync());
        }

        // GET: Saches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.MaNxbNavigation)
                .Include(s => s.MaTacGiaNavigation)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Saches/Create
        public IActionResult Create()
        {
            ViewData["MaNxb"] = new SelectList(_context.Nxbs, "MaNxb", "MaNxb");
            ViewData["MaTacGia"] = new SelectList(_context.Tacgia, "MaTacGia", "MaTacGia");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSach,MaNxb,MaTacGia,TenSach,MaTheLoai,MaViTri,NamXb,SoLuong,Muon,LanTaiBan,NgonNgu")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNxb"] = new SelectList(_context.Nxbs, "MaNxb", "MaNxb", sach.MaNxb);
            ViewData["MaTacGia"] = new SelectList(_context.Tacgia, "MaTacGia", "MaTacGia", sach.MaTacGia);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["MaNxb"] = new SelectList(_context.Nxbs, "MaNxb", "MaNxb", sach.MaNxb);
            ViewData["MaTacGia"] = new SelectList(_context.Tacgia, "MaTacGia", "MaTacGia", sach.MaTacGia);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSach,MaNxb,MaTacGia,TenSach,MaTheLoai,MaViTri,NamXb,SoLuong,Muon,LanTaiBan,NgonNgu")] Sach sach)
        {
            if (id != sach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
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
            ViewData["MaNxb"] = new SelectList(_context.Nxbs, "MaNxb", "MaNxb", sach.MaNxb);
            ViewData["MaTacGia"] = new SelectList(_context.Tacgia, "MaTacGia", "MaTacGia", sach.MaTacGia);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Saches
                .Include(s => s.MaNxbNavigation)
                .Include(s => s.MaTacGiaNavigation)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sach = await _context.Saches.FindAsync(id);
            if (sach != null)
            {
                _context.Saches.Remove(sach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(string id)
        {
            return _context.Saches.Any(e => e.MaSach == id);
        }
    }
}
