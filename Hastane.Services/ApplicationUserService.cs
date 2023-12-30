using Hastane.Models;
using Hastane.Repositories.Interfaces;
using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteUser(int id)
        {
            var model = _unitOfWork.GenericRepository<ApplicationUser>().GetById(id);
            _unitOfWork.GenericRepository<ApplicationUser>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public ApplicationUserViewModel GetUserById(int UserId)
        {
            var model = _unitOfWork.GenericRepository<ApplicationUser>().GetById(UserId);
            var vm = new ApplicationUserViewModel(model);
            return vm;
        }


        public PagedResult<ApplicationUserViewModel> GetAllHasta(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ApplicationUserViewModel user)
        {
            var model = new ApplicationUserViewModel().ConvertViewModel(user);
            var ModelById = _unitOfWork.GenericRepository<ApplicationUser>().GetById(model.Id);
            ModelById.Name = user.Name;
            ModelById.Gender = user.Gender;
            ModelById.Address = user.Address;
            ModelById.DateOfBirth = user.DateOfBirth;
            ModelById.Email = user.Email;
            _unitOfWork.GenericRepository<ApplicationUser>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
}
