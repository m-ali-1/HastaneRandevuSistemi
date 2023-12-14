using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IClinicService
    {
        PagedResult<ClinicViewModel> GetAll(int pageNumber, int pageSize);
        ClinicViewModel GetClinicById(int ClinicId);
        void UpdateClinic(ClinicViewModel Clinic);
        void InsertClinic(ClinicViewModel Clinic);
        void DeleteClinic(int id);
    }
}
