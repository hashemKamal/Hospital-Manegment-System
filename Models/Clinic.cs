//namespace Hospital.Models
//{
//    public class Clinic
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }

//        public ICollection<Doctor> Doctors { get; set; }
//    }
//}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Clinic
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        // علاقة كل Clinic بعدة Doctors
        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
