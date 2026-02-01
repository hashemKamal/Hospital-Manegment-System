using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Hospital.Controllers
{
    public class ClinicController : Controller
    {
        private readonly HospitalContext _context;

        public ClinicController(HospitalContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            var clinics = _context.Clinics.ToList();
            return View(clinics);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Clinics.Add(clinic);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(clinic);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var clinic = _context.Clinics.Find(id);
            if (clinic == null) return NotFound();
            return View(clinic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Clinics.Update(clinic);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(clinic);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var clinic = _context.Clinics.Find(id);
            if (clinic == null) return NotFound();
            return View(clinic);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var clinic = _context.Clinics.Find(id);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
