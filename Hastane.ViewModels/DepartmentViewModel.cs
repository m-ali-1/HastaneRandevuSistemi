using Hastane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hastane.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public DepartmentViewModel()
        {
                
        }
        public DepartmentViewModel(Department model)
        {
            Id= model.Id;
            Name= model.Name;
            Type= model.Type;
            Description= model.Description;
        }
        public Department ConvertViewModel(DepartmentViewModel model)
        {
            return new Department
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                Description = model.Description
            };
        }
    }
}
