namespace Hospital.Models;
//{
//    public class Appointment
//    {
//        public int Id { get; set; }
//        public string Title { get; set; }
//        public DateTime Date { get; set; }
//        public int PatientId { get; set; }
//        public int DoctorId { get; set; }

//        // Add navigation properties for Doctor and Patient
//        public Doctor Doctor { get; set; }
//        public Patient Patient { get; set; }
//    }
//}
public class Appointment
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
}
