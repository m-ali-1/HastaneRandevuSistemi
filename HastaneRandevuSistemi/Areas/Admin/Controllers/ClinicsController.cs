using Hastane.Models;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ClinicsController : Controller
    {
        private IClinicService _clinic;
        public ClinicsController(IClinicService clinic)
        {
            _clinic = clinic;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_clinic.GetAll(pageNumber, pageSize));
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _clinic.GetClinicById(id);
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(ClinicViewModel vm)
        {
            _clinic.UpdateClinic(vm);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(ClinicViewModel vm)
        {
            _clinic.InsertClinic(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _clinic.DeleteClinic(id);
            return RedirectToAction("Index");
        }
    }
}
