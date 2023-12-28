using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hastane.Models
{
    public class Randevu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime RandevuTarih { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string HastaEmail { get; set; }


    }
}