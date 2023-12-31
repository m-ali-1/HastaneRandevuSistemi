using Hastane.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [Display(Name = "İsim")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Doktor Mu?")]
        public bool IsDoctor { get; set; }
        [Display(Name = "Doktor Id")]
        public string UserId { get; set; }
        [Display(Name = "Uzmanlığı veya Ünvanı")]
        public string Specialist { get; set; }
        [Display(Name = "Poliklinik Id")]
        public int ClinicInfo { get; set; }
        public Clinic Clinic { get; set; }
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
            UserId = doctor.UserId;
            ClinicInfo = doctor.ClinicId;
            Clinic = doctor.Clinic;

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
                UserId = doctor.UserId,
                ClinicId = doctor.ClinicInfo,
                Clinic = doctor.Clinic
            };
        }
    }
}