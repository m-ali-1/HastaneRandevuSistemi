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
    public class DepartmentService : IDepartmentInfo
    {
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteDepartmentInfo(int id)
        {
            var model = _unitOfWork.GenericRepository<Department>().GetById(id);
            _unitOfWork.GenericRepository<Department>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<DepartmentViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new DepartmentViewModel();
            int totalCount;
            List<DepartmentViewModel> vmList = new List<DepartmentViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Department>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Department>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<DepartmentViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;

        }

        public DepartmentViewModel GetDepartmentById(int DepartmentId)
        {
            var model = _unitOfWork.GenericRepository<Department>().GetById(DepartmentId);
            var vm = new DepartmentViewModel(model);
            return vm;
        }

        public void InsertDepartmentInfo(DepartmentViewModel departmentInfo)
        {
            var model = new DepartmentViewModel().ConvertViewModel(departmentInfo);
            _unitOfWork.GenericRepository<Department>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateDepartmentInfo(DepartmentViewModel departmentInfo)
        {
            var model = new DepartmentViewModel().ConvertViewModel(departmentInfo);
            var ModelById = _unitOfWork.GenericRepository<Department>().GetById(model.Id);
            ModelById.Name = departmentInfo.Name;
            ModelById.Type = departmentInfo.Type;
            _unitOfWork.GenericRepository<Department>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<DepartmentViewModel> ConvertModelToViewModelList(List<Department> modelList)
        {
            return modelList.Select(x => new DepartmentViewModel(x)).ToList();
        }
    }
}
