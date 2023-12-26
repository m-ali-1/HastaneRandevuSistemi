namespace Hastane.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}