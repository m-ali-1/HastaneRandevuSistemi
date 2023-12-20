using Hastane.Models;
using Hastane.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Utilities
{
    public class DbInitializier : IDbInitializier
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializier(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Hasta)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                var AppUser = new IdentityUser
                {
                    UserName = "ali@denemeali.com",
                    Email = "ali@denemeali.com"
                };

                _userManager.CreateAsync(AppUser, "AliDeneme.123").GetAwaiter().GetResult();

                var createdAppUser = _context.Users.FirstOrDefault(x => x.Email == "ali@denemeali.com");
                if (createdAppUser != null)
                {
                    _userManager.AddToRoleAsync(createdAppUser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }


        }
    }
}
