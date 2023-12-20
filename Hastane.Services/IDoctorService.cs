using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IDoctorService
    {
        PagedResult<DoctorViewModel> GetAllDoctor(int pageNumber, int pageSize);
        DoctorViewModel GetDoctorById(int DoctorId);
        void UpdateDoctor(DoctorViewModel Doctor);
        void InsertDoctor(DoctorViewModel Doctor);
        void DeleteDoctor(int id);
    }
}
