// RandevuController.cs

using System;
using Microsoft.AspNetCore.Mvc;
using Hastane.Services;
using Hastane.ViewModels;

namespace Hastane.Controllers
{
    [Area("Admin")]
    public class RandevuController : Controller
    {
        private readonly IRandevuService _randevuService;

        public RandevuController(IRandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        // Randevu alma sayfası
        public IActionResult RandevuAl()
        {
            // Gerekirse, doktor listesi, saat aralıkları vb. view'e geçirilebilir.
            return View();
        }

        [HttpPost]
        public IActionResult RandevuAl(RandevuViewModel randevuViewModel)
        {
            if (ModelState.IsValid)
            {
                // ViewModel'den alınan bilgilerle randevu alma işlemini gerçekleştir.
                bool randevuAlindi = _randevuService.RandevuAl(
                    randevuViewModel.HastaEmail,
                    randevuViewModel.RandevuTarih,
                    randevuViewModel.DoctorId,
                    randevuViewModel.Description
                );

                if (randevuAlindi)
                {
                    // Başarılı bir şekilde randevu alındıysa, başka bir sayfaya yönlendirme yapabilirsiniz.
                    return RedirectToAction("Randevularim");
                }

                ModelState.AddModelError("", "Randevu alınamadı. Lütfen tekrar deneyin.");
            }

            // Hata durumunda tekrar randevu alma sayfasını göster.
            return View(randevuViewModel);
        }

        // Randevu iptal sayfası
        public IActionResult RandevuIptal(int randevuId)
        {
            // Gerekirse, randevu detayları view'e geçirilebilir.
            return View();
        }

        [HttpPost]
        public IActionResult RandevuIptalConfirmed(int randevuId)
        {
            bool randevuIptalEdildi = _randevuService.RandevuIptal(randevuId);

            if (randevuIptalEdildi)
            {
                // Başarılı bir şekilde randevu iptal edildiyse, başka bir sayfaya yönlendirme yapabilirsiniz.
                return RedirectToAction("Randevularim", new { hastaMail = "hastaIdBurayaEklenecek" });
            }

            // Hata durumunda tekrar randevu iptal sayfasını göster.
            return View();
        }

        // Hasta randevularını listeleyen sayfa
        public IActionResult Randevularim(string hastaMail)
        {
            // Hasta id'sine göre randevuları getir ve view'e geçir.
            var randevular = _randevuService.GetRandevularByHastaId(hastaMail);

            // Randevu modelini RandevuViewModel'e dönüştür.
            var randevuViewModels = randevular.Select(r => new RandevuViewModel
            {
                Id = r.Id,
                HastaEmail = r.HastaEmail,
                RandevuTarih = r.RandevuTarih,
                DoctorId = r.DoctorId,
                Description = r.Description
            }).ToList();

            return View(randevuViewModels);
        }

        // Diğer gerekli action metodları buraya eklenir.
    }
}
