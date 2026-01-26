using Microsoft.AspNetCore.Mvc;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace Hospital.Controllers
{
    public class AppointmentController : Controller
        {
            private readonly HospitalContext _context;

            public AppointmentController(HospitalContext context)
            {
                _context = context;
            }

            // READ
            public IActionResult Index()
            {
                var appointments = _context.Appointments
                    .Include(a => a.Doctor)
                    .Include(a => a.Patient)
                    .ToList();
                return View(appointments);
            }

            // CREATE
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Appointment appointment)
            {
                // تأكد إن DoctorId و PatientId موجودين فعلاً في الداتابيز
                bool doctorExists = _context.Doctors.Any(d => d.Id == appointment.DoctorId);
                bool patientExists = _context.Patients.Any(p => p.Id == appointment.PatientId);

                if (!doctorExists || !patientExists)
                {
                    ModelState.AddModelError("", "Please select valid Doctor and Patient.");
                }

                if (ModelState.IsValid)
                {
                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                // إعادة تحميل الـ dropdowns لو حصل خطأ
                ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name");
                ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");

                return View(appointment);
            }

            // EDIT
            public IActionResult Edit(int id)
            {
                var appointment = _context.Appointments.Find(id);
                if (appointment == null) return NotFound();
                return View(appointment);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Appointment appointment)
            {
                if (ModelState.IsValid)
                {
                    _context.Appointments.Update(appointment);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(appointment);
            }

            // DELETE
            public IActionResult Delete(int id)
            {
                var appointment = _context.Appointments.Find(id);
                if (appointment == null) return NotFound();
                return View(appointment);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                var appointment = _context.Appointments.Find(id);
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }

