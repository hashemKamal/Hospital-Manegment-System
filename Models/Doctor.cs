namespace Hospital.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Clinic> Clinics { get; set; } = new List<Clinic>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
