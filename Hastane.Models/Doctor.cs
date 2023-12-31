﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public int ClinicId { get; set; }
        public string UserId { get; set; }
        public ICollection<Randevu> Randevus { get; set; }
        [JsonIgnore]
        public Clinic Clinic { get; set; }
    }
}
