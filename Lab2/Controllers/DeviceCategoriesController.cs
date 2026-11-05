using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class DeviceCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceCategories
        public async Task<IActionResult> Index()
        {
            var categories = await _context.DeviceCategories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();

            return View(categories);
        }

        // GET: DeviceCategories/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.DeviceCategories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: DeviceCategories/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.DeviceCategories
                .FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: DeviceCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, DeviceCategory category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var existingCategory = await _context.DeviceCategories
                .FindAsync(id);

            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: DeviceCategories/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.DeviceCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: DeviceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.DeviceCategories
                .FindAsync(id);

            bool hasDevices = await _context.Devices
                .AnyAsync(d => d.CategoryId == id);

            if (hasDevices)
            {
                TempData["ErrorMessage"] =
                    "Cannot delete this category because it contains devices.";

                return RedirectToAction(nameof(Index));
            }

            if (category == null)
            {
                return NotFound();
            }

            _context.DeviceCategories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}