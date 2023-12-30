using Hastane.Models;
using Hastane.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hastane.Services
{
    public class RandevuService : IRandevuService
    {
        private readonly ApplicationDbContext _context;

        public RandevuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Randevu GetRandevuById(int randevuId)
        {
            return _context.Randevus.FirstOrDefault(r => r.Id == randevuId);
        }

        public List<Randevu> GetRandevularByHastaId(string hastaMail)
        {
            return _context.Randevus.Where(r => r.HastaEmail == hastaMail).ToList();
        }

        public List<Randevu> GetRandevularByDate(DateTime randevuTarih)
        {
            return _context.Randevus.Where(r => r.RandevuTarih.Date == randevuTarih.Date).ToList();
        }
        public List<Randevu> GetAllRandevular()
        {
            // Tüm randevuları veritabanından çekme işlemini gerçekleştirin.
            return _context.Randevus.ToList();
        }

        public List<Randevu> GetRandevularByDoctorId(int doctorId)
        {
            return _context.Randevus.Where(r => r.DoctorId == doctorId).ToList();
        }

        public bool RandevuAl(string hastaMail, DateTime randevuTarih, int doctorId, string description)
        {
            try { 
            // Randevu oluşturma işlemleri burada gerçekleştirilebilir.
            // Örneğin, çakışan randevuları kontrol etmek gibi.

            Randevu yeniRandevu = new Randevu
            {
                RandevuTarih = randevuTarih,
                Description = description,
                DoctorId = doctorId,
                HastaEmail = hastaMail
            };

            // Veritabanına yeni randevuyu ekleyin.
            _context.Randevus.Add(yeniRandevu);
            _context.SaveChanges(); // Değişiklikleri kaydet.
            return true;
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapabilir veya hata mesajını gönderebilirsiniz.
                Console.WriteLine($"Randevu alma sırasında bir hata oluştu: {ex.Message}");
                return false; // Hata durumunda false döndür.
            }
        }

        public bool RandevuIptal(int randevuId)
        {
            Randevu randevu = GetRandevuById(randevuId);
            if (randevu != null)
            {
                _context.Randevus.Remove(randevu);
                return true; // Başarıyla randevu iptal edildi.
            }

            return false; // Randevu bulunamadı.
        }
    }
}
