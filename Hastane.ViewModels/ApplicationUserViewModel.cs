﻿using Hastane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ApplicationUserViewModel()
        {

        }
        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            Gender = user.Gender;
            Address = user.Address;
            DateOfBirth = user.DateOfBirth;
            Appointments = user.Appointments;
            Email = user.Email;
            UserName = user.UserName;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
        }
        public ApplicationUser ConvertViewModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                Gender = user.Gender,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Appointments = user.Appointments,
                Email = user.Email,
                UserName = user.UserName,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist
            };
        }
    }
}