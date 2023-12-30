using Hastane.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hastane.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ana Bilim Dalı")]
        public string Name { get; set; }
        [Display(Name = "Türü")]
        public string Type { get; set; }
        [Display(Name = "Açıklama")]
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
