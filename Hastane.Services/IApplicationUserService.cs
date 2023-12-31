﻿using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IApplicationUserService
    {
        PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize);
        PagedResult<ApplicationUserViewModel> GetAllHasta(int pageNumber, int pageSize);
        ApplicationUserViewModel GetUserById(int id);
        void UpdateUser(ApplicationUserViewModel user);
        void DeleteUser(int id);


    }
}
