namespace Hospital.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Medicine { get; set; }
    }
}
