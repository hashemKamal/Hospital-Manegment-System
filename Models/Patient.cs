//namespace Hospital.Models
//{
//    public class Patient
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public ICollection<Appointment> Appointments { get; set; }
//        public int PrimaryDoctorId { get; set; }
//        public Doctor PrimaryDoctor { get; set; }
//    }
//}
namespace Hospital.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int? PrimaryDoctorId { get; set; }
    public Doctor? PrimaryDoctor { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
