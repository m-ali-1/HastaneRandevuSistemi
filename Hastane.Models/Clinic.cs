using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hastane.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [JsonIgnore]
        public ICollection<Doctor> Doctors { get; set; }
    }
}