using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_Layer.Utility
{
    public class DBSeeding : IDBSeeding
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DBSeeding(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,ApplicationDbContext context)
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

            //Check if default Admin user exists or not
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                //Create User Roles in the database
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Student")).GetAwaiter().GetResult();


                //Note: Password should always have one Capital alphabet and one Special Character
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "aakash",
                    Email = "aakashgupta333@gmail.com"                                                      //Password = "Admin@123"
                }, "admin@123").GetAwaiter().GetResult();

                //Get the default Admin User, which is created above.
                var Appuser = _context.Users.FirstOrDefault(x => x.Email == "aakashgupta333@gmail.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, "Admin").GetAwaiter().GetResult();
                }
            }
        }

    }


    public interface IDBSeeding
    {
        void Initialize();
    }
}
