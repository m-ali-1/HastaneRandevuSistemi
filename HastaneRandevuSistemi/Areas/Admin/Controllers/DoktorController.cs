using Hastane.Models;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace HastaneRandevuSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoktorController : Controller
    {
        private IDoctorService _doctorService;
        public DoktorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public IActionResult AllDoctors(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctorService.GetAllDoctor(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _doctorService.GetDoctorById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(DoctorViewModel vm)
        {
            _doctorService.UpdateDoctor(vm);
            return RedirectToAction("AllDoctors");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DoctorViewModel vm)
        {
            _doctorService.InsertDoctor(vm);
            return RedirectToAction("AllDoctors");
        }
        public IActionResult Delete(int id)
        {
            _doctorService.DeleteDoctor(id);
            return RedirectToAction("AllDoctors");

        }

    }
}
