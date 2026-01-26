//using Hospital.Data;
//using Hospital.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Hospital.Controllers
//{
//    public class DoctorController : Controller
//    {
//        private readonly HospitalContext _context;

//        public DoctorController(HospitalContext context)
//        {
//            _context = context;
//        }

//        // GET: Doctor
//        public IActionResult Index()
//        {
//            var doctors = _context.Doctors.ToList();
//            return View(doctors);
//        }

//        // GET: Doctor/Create
//        public IActionResult Create()
//        {
//            return View("CreateDoctor");
//        }

//        // POST: Doctor/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult CreateDoctor(Doctor doctor)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Doctors.Add(doctor);
//                _context.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(doctor);
//        }

//        // GET: Doctor/Delete/5
//        public IActionResult Delete(int id)
//        {
//            var doctor = _context.Doctors.Find(id);
//            if (doctor == null) return NotFound();

//            return View(doctor);
//        }

//        // POST: Doctor/Delete
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var doctor = _context.Doctors.Find(id);
//            if (doctor != null)
//            {
//                _context.Doctors.Remove(doctor);
//                _context.SaveChanges();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalContext _context;

        public DoctorController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Doctor or /Doctor/Index
        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        // GET: /Doctor/IndexDoctor (بدون تكرار View)
        public IActionResult IndexDoctor()
        {
            var doctors = _context.Doctors.ToList();
            return View("Index", doctors); // تستخدم نفس View Index
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public IActionResult Edit(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }


        // GET: Doctor/Delete/5
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // POST: Doctor/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
