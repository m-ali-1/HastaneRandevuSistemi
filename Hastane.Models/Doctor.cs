namespace Hastane.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
