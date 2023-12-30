// IRandevuService.cs

using Hastane.Models;
using System;
using System.Collections.Generic;

namespace Hastane.Services
{
    public interface IRandevuService
    {
        Randevu GetRandevuById(int randevuId);
        List<Randevu> GetRandevularByHastaId(string hastaMail);
        List<Randevu> GetAllRandevular();
        List<Randevu> GetRandevularByDate(DateTime randevuTarih);
        List<Randevu> GetRandevularByDoctorId(int doctorId);
        bool RandevuAl(string hastaMail, DateTime randevuTarih, int doctorId, string description);
        bool RandevuIptal(int randevuId);
    }
}
