using Hastane.Models;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace HastaneRandevuSistemi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Hasta")]
    public class DoktorController : Controller
    {
        private IDoctorService _doctorService;
        public DoktorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [Authorize(Roles = "Admin, Hasta")]
        public IActionResult AllDoctors(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctorService.GetAllDoctor(pageNumber, pageSize));

        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _doctorService.GetDoctorById(id);
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(DoctorViewModel vm)
        {
            _doctorService.UpdateDoctor(vm);
            return RedirectToAction("AllDoctors");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(DoctorViewModel vm)
        {
            _doctorService.InsertDoctor(vm);
            return RedirectToAction("AllDoctors");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _doctorService.DeleteDoctor(id);
            return RedirectToAction("AllDoctors");

        }

    }
}
