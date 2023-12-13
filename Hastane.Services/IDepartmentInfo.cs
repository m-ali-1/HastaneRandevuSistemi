using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IDepartmentInfo
    {
        PagedResult<DepartmentViewModel> GetAll(int pageNumber, int pageSize);

        DepartmentViewModel GetDepartmentById(int DepartmentId);
        void UpdateDepartmentInfo(DepartmentViewModel departmentInfo);
        void InsertDepartmentInfo(DepartmentViewModel departmentInfo);
        void DeleteDepartmentInfo(int id);
    }
}
