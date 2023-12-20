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
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<DoctorViewModel> GetAllDoctor(int pageNumber, int pageSize)
        {
            var vm = new DoctorViewModel();
            int totalCount;
            List<DoctorViewModel> vmList = new List<DoctorViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Doctor>().GetAll(x => x.IsDoctor == true)
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Doctor>().GetAll(x => x.IsDoctor == true).ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<DoctorViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public void DeleteDoctor(int id)
        {
            var model = _unitOfWork.GenericRepository<Doctor>().GetById(id);
            _unitOfWork.GenericRepository<Doctor>().Delete(model);
            _unitOfWork.Save();
        }

        public DoctorViewModel GetDoctorById(int DoctorId)
        {
            var model = _unitOfWork.GenericRepository<Doctor>().GetById(DoctorId);
            var vm = new DoctorViewModel(model);
            return vm;
        }

        public void InsertDoctor(DoctorViewModel Doctor)
        {
            var model = new DoctorViewModel().ConvertViewModel(Doctor);
            _unitOfWork.GenericRepository<Doctor>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateDoctor(DoctorViewModel Doctor)
        {
            var model = new DoctorViewModel().ConvertViewModel(Doctor);
            var ModelById = _unitOfWork.GenericRepository<Doctor>().GetById(model.Id);
            ModelById.Id = Doctor.Id;
            ModelById.IsDoctor = Doctor.IsDoctor;
            ModelById.Name = Doctor.Name;
            ModelById.Email = Doctor.Email;
            ModelById.Address = Doctor.Address;
            ModelById.DateOfBirth = Doctor.DateOfBirth;
            ModelById.Gender = Doctor.Gender;
            ModelById.Specialist = Doctor.Specialist;
            ModelById.ClinicId= Doctor.ClinicId;
            _unitOfWork.GenericRepository<Doctor>().Update(ModelById);
            _unitOfWork.Save();
        }
        private List<DoctorViewModel> ConvertModelToViewModelList(List<Doctor> modelList)
        {
            return modelList.Select(x => new DoctorViewModel(x)).ToList();
        }
    }
}
