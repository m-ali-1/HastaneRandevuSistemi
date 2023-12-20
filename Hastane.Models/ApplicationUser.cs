using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Specialist { get; set; }
        public bool IsDoctor { get; set; }
        [NotMapped]
        public ICollection<Appointment> Appointments { get; set; }
    }
}

namespace Hastane.Models
{
    public enum Gender
    {
        Male,
        Female
    }
}