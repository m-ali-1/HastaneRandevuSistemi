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
    public class ClinicService : IClinicService
    {
        private IUnitOfWork _unitOfWork;

        public ClinicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteClinic(int id)
        {
            var model = _unitOfWork.GenericRepository<Clinic>().GetById(id);
            _unitOfWork.GenericRepository<Clinic>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ClinicViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ClinicViewModel();
            int totalCount;
            List<ClinicViewModel> vmList = new List<ClinicViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Clinic>().GetAll(includeProperties:"Department")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Clinic>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<ClinicViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public ClinicViewModel GetClinicById(int ClinicId)
        {
            var model = _unitOfWork.GenericRepository<Clinic>().GetById(ClinicId);
            var vm = new ClinicViewModel(model);
            return vm;
        }

        public void InsertClinic(ClinicViewModel Clinic)
        {
            var model = new ClinicViewModel().ConvertViewModel(Clinic);
            _unitOfWork.GenericRepository<Clinic>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateClinic(ClinicViewModel Clinic)
        {
            var model = new ClinicViewModel().ConvertViewModel(Clinic);
            var ModelById = _unitOfWork.GenericRepository<Clinic>().GetById(model.Id);
            ModelById.Number = Clinic.Number;
            ModelById.Status = Clinic.Status;
            ModelById.DepartmentId = Clinic.DepartmentInfo;
            _unitOfWork.GenericRepository<Clinic>().Update(ModelById);
            _unitOfWork.Save();
        }

        private List<ClinicViewModel> ConvertModelToViewModelList(List<Clinic> modelList)
        {
            return modelList.Select(x => new ClinicViewModel(x)).ToList();
        }
    }
}
