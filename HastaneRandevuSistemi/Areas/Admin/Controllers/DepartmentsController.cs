using cloudscribe.Pagination.Models;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentsController : Controller
    {
        private IDepartmentInfo _departmentInfo;

        public DepartmentsController(IDepartmentInfo departmentInfo)
        {
            _departmentInfo = departmentInfo;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_departmentInfo.GetAll(pageNumber,pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _departmentInfo.GetDepartmentById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel vm)
        {
            _departmentInfo.UpdateDepartmentInfo(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel vm)
        {
            _departmentInfo.InsertDepartmentInfo(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _departmentInfo.DeleteDepartmentInfo(id);
            return RedirectToAction("Index");
        }
    }
}
