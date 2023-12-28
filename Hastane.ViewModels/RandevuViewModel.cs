// RandevuViewModel.cs

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    }
}
