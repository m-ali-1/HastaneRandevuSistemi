using Hastane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDoctor { get; set; }
        public string UserId { get; set; }
        public string Specialist { get; set; }
        public ICollection<Randevu> Randevus { get; set; }
        public int ClinicId { get; set; }
        public DoctorViewModel()
        {

        }
        public DoctorViewModel(Doctor doctor)
        {
            Id = doctor.Id;
            Name = doctor.Name;
            Email = doctor.Email;
            Gender = doctor.Gender;
            Address = doctor.Address;
            DateOfBirth = doctor.DateOfBirth;
            IsDoctor = doctor.IsDoctor;
            Specialist = doctor.Specialist;
            Randevus = doctor.Randevus;
            ClinicId = doctor.ClinicId;
            UserId = doctor.UserId;

        }
        public Doctor ConvertViewModel(DoctorViewModel doctor)
        {
            return new Doctor
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Email = doctor.Email,
                Gender = doctor.Gender,
                Address = doctor.Address,
                DateOfBirth = doctor.DateOfBirth,
                IsDoctor = doctor.IsDoctor,
                Specialist = doctor.Specialist,
                Randevus = doctor.Randevus,
                ClinicId = doctor.ClinicId,
                UserId = doctor.UserId
            };
        }
    }
}