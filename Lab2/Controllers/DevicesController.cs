using Lab2.Data;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _context.DeviceCategories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name"
            );
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            string? searchString,
            int? categoryId,
            DeviceStatus? status)
        {
            var query = _context.Devices
                .Include(d => d.Category)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();

                query = query.Where(d =>
                    d.Name.Contains(searchString) ||
                    d.Code.Contains(searchString));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(d =>
                    d.CategoryId == categoryId.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(d =>
                    d.Status == status.Value);
            }

            var devices = await query
                .OrderBy(d => d.Name)
                .ToListAsync();

            var categories = await _context.DeviceCategories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name",
                categoryId
            );

            ViewBag.SearchString = searchString;
            ViewBag.SelectedStatus = status;

            return View(devices);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCategoriesAsync();

            return View(new Device());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,Code,Status,DateOfEntry,CategoryId")] Device device)
        {
            if (await _context.Devices.AnyAsync(d => d.Code == device.Code))
            {
                ModelState.AddModelError("Code", "Device code already exists.");
            }

            bool categoryExists = await _context.DeviceCategories
                .AnyAsync(c => c.Id == device.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError("CategoryId", "Invalid category.");
            }

            if (!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return View(device);
            }

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            await LoadCategoriesAsync();

            return View(device);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name,Code,Status,DateOfEntry,CategoryId")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            bool duplicateCode = await _context.Devices
                .AnyAsync(d => d.Code == device.Code && d.Id != id);

            if (duplicateCode)
            {
                ModelState.AddModelError("Code", "Device code already exists.");
            }

            bool categoryExists = await _context.DeviceCategories
                .AnyAsync(c => c.Id == device.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError("CategoryId", "Invalid category.");
            }

            if (!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return View(device);
            }

            var existingDevice = await _context.Devices.FindAsync(id);

            if (existingDevice == null)
            {
                return NotFound();
            }

            existingDevice.Name = device.Name;
            existingDevice.Code = device.Code;
            existingDevice.Status = device.Status;
            existingDevice.DateOfEntry = device.DateOfEntry;
            existingDevice.CategoryId = device.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _context.Devices
                .Include(d => d.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}