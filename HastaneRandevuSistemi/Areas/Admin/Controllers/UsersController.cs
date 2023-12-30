using Hastane.Models;
using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HastaneRandevuSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UsersController : Controller
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_userService.GetAll(pageNumber,pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _userService.GetUserById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUserViewModel vm)
        {
            _userService.UpdateUser(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}
