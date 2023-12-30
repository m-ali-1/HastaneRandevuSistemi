using Hastane.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Helpers;
using System.Xml.Linq;

namespace Hastane.ViewModels
{
    public class RandevuViewModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string HastaEmail { get; set; }
        public int Id { get; set; } // Id özelliğini ekledik
        public DateTime RandevuTarih { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        // İhtiyaca göre diğer gerekli alanları ekleyebilirsiniz.

        public RandevuViewModel()
        {

        }
        public RandevuViewModel(Randevu randevu)
        {
            Id = randevu.Id;
            HastaEmail = randevu.HastaEmail;
            Description = randevu.Description;
            RandevuTarih = randevu.RandevuTarih;
            DoctorId = randevu.DoctorId;

        }
        public Randevu ConvertViewModel(RandevuViewModel randevu)
        {
            return new Randevu
            {
                Id = randevu.Id,
                HastaEmail = randevu.HastaEmail,
                Description = randevu.Description,
                RandevuTarih = randevu.RandevuTarih,
                DoctorId = randevu.DoctorId
            };
        }
    }
}
