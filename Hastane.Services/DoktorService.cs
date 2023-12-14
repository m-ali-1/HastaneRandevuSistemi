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
    public class DoktorService : IDoktorService
    {
        private IUnitOfWork _unitOfWork;

        public DoktorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeleteDoktor(int id)
        {
            var model = _unitOfWork.GenericRepository<Doktor>().GetById(id);
            _unitOfWork.GenericRepository<Doktor>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<DoktorViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new DoktorViewModel();
            int totalCount;
            List<DoktorViewModel> vmList = new List<DoktorViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Doktor>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepository<Doktor>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }

            var result = new PagedResult<DoktorViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public DoktorViewModel GetDoktorById(int DoktorId)
        {
            var model = _unitOfWork.GenericRepository<Doktor>().GetById(DoktorId);
            var vm = new DoktorViewModel(model);
            return vm;
        }

        public void InsertDoktor(DoktorViewModel Doktor)
        {
            var model = new DoktorViewModel().ConvertViewModel(Doktor);
            _unitOfWork.GenericRepository<Doktor>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateDoktor(DoktorViewModel Doktor)
        {
            var model = new DoktorViewModel().ConvertViewModel(Doktor);
            var ModelById = _unitOfWork.GenericRepository<Doktor>().GetById(model.Id);
            ModelById.Name = Doktor.Name;
            ModelById.Description = Doktor.Description;
            ModelById.Title = Doktor.Title;
            ModelById.ClinicId = Doktor.ClinicInfoId;
            _unitOfWork.GenericRepository<Doktor>().Update(ModelById);
            _unitOfWork.Save();
        }
        private List<DoktorViewModel> ConvertModelToViewModelList(List<Doktor> modelList)
        {
            return modelList.Select(x => new DoktorViewModel(x)).ToList();
        }
    }
}
