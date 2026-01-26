using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hospital.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly HospitalContext _context;

        public PrescriptionController(HospitalContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var prescriptions = _context.Prescriptions.ToList();
            return View(prescriptions);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            if (prescription == null) return NotFound();
            return View(prescription);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescriptions.Update(prescription);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(prescription);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            if (prescription == null) return NotFound();
            return View(prescription);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var prescription = _context.Prescriptions.Find(id);
            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
