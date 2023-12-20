using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoktorUserController : Controller
    {
        private IDoctorService _doctorService;
        public DoktorUserController(IDoctorService doctorService)
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _doctorService.DeleteDoctor(id);
            return RedirectToAction("Index");
        }
    }
}
