using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.Library
{
    public class LUsuarios : ListObject
    {
        public LUsuarios()
        {

        }

        public LUsuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _usersRoles = new UsersRoles();
        }

        public LUsuarios(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _usersRoles = new UsersRoles();
        }

        internal async Task<List<object[]>> UserLogin(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = _userManager.Users.Where(u => u.Email.Equals(email));
                }
            }
            catch (Exception ex)
            {
                Description = ex.Message;
            }
            return null;
        }
    }
}
