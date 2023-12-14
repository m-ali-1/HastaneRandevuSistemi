using Hastane.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.ViewModels
{
    public class DoktorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int ClinicInfoId { get; set; }
        public DoktorViewModel()
        {

        }
        public DoktorViewModel(Doktor model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Title = model.Title;
            ClinicInfoId = model.ClinicId;

        }
        public Doktor ConvertViewModel(DoktorViewModel model)
        {
            return new Doktor
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Title = model.Title,
                ClinicId = model.ClinicInfoId
            };
        }
    }
}