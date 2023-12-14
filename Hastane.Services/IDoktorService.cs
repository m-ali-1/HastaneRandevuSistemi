using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IDoktorService
    {
        PagedResult<DoktorViewModel> GetAll(int pageNumber, int pageSize);
        DoktorViewModel GetDoktorById(int DoktorId);
        void UpdateDoktor(DoktorViewModel Doktor);
        void InsertDoktor(DoktorViewModel Doktor);
        void DeleteDoktor(int id);
    }
}
