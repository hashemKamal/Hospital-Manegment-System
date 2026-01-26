using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;


namespace newProject.Controllers
{
    public class StaffController : Controller
    {
        private readonly HospitalContext _context;

        public StaffController(HospitalContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Staff.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staff.Add(staff);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public IActionResult Edit(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Staff.Update(staff);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public IActionResult Delete(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var staff = _context.Staff.Find(id);
            _context.Staff.Remove(staff);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
