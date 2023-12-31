using System;
using Microsoft.AspNetCore.Mvc;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Hastane.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IRandevuService _randevuService;

        public RandevuController(IRandevuService randevuService)
        {
            _randevuService = randevuService;
        }

        public IActionResult RandevuAl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RandevuAl(RandevuViewModel randevuViewModel)
        {
            if (ModelState.IsValid)
            {
                bool randevuAlindi = _randevuService.RandevuAl(
                    randevuViewModel.HastaEmail,
                    randevuViewModel.RandevuTarih,
                    randevuViewModel.DoctorId,
                    randevuViewModel.Description
                );

                if (randevuAlindi)
                {
                    return RedirectToAction("Randevularim");
                }

                ModelState.AddModelError("", "Randevu alınamadı. Lütfen tekrar deneyin.");
            }

            return View(randevuViewModel);
        }

        public IActionResult RandevuIptal(int randevuId)
        {
            // RandevuId'ye göre randevu bilgilerini getir
            var randevu = _randevuService.GetRandevuById(randevuId);

            if (randevu == null)
            {
                return NotFound();
            }

            var randevuViewModel = new RandevuViewModel
            {
                Id = randevu.Id,
                HastaEmail = randevu.HastaEmail,
                RandevuTarih = randevu.RandevuTarih,
                DoctorId = randevu.DoctorId,
                Description = randevu.Description
            };

            return View(randevuViewModel);
        }

        [HttpPost]
        public IActionResult RandevuIptalConfirmed(int id)
        {
            bool randevuIptalEdildi = _randevuService.RandevuIptal(id);

            if (randevuIptalEdildi)
            {
                return RedirectToAction("Randevularim", new { hastaMail = "hastaIdBurayaEklenecek" });
            }

            return View();
        }

        public IActionResult Randevularim()
        {
            // Kullanıcı oturum açmış mı kontrol et
            if (User.Identity.IsAuthenticated)
            {
                // Admin rolüne sahip kullanıcılar tüm randevuları görebilir
                if (User.IsInRole("Admin"))
                {
                    var randevular = _randevuService.GetAllRandevular();

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
                else
                {
                    string hastaMail = User.Identity.Name;

                    var randevular = _randevuService.GetRandevularByHastaId(hastaMail);

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
            }
            return RedirectToAction("Login");
        }
    }
}
