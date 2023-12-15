using Hastane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class ClinicViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public int DepartmentInfo { get; set; }
        public Department Department { get; set; }
        public ClinicViewModel()
        {

        }
        public ClinicViewModel(Clinic model)
        {
            Id = model.Id;
            Number = model.Number;
            Status = model.Status;
            DepartmentInfo = model.DepartmentId;
            Department = model.Department;
            
        }
        public Clinic ConvertViewModel(ClinicViewModel model)
        {
            return new Clinic
            {
                Id = model.Id,
                Number = model.Number,
                Status = model.Status,
                DepartmentId = model.DepartmentInfo,
                Department = model.Department
            };
        }



    }
}
