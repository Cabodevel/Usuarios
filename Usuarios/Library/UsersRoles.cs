using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Usuarios.Library
{
    public class UsersRoles : ListObject
    {
        public UsersRoles()
        {
            _userRoles = new List<SelectListItem>();
        }

        public async Task<List<SelectListItem>> GetRole(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, string Id)
        {
            var users = await userManager.FindByIdAsync(Id);
            var roles = await userManager.GetRolesAsync(users);

            if (roles.Count().Equals(0))
            {
                _userRoles.Add(new SelectListItem{
                    Value = "0",
                    Text = "Sin rol"
                });
            }
            else
            {
                var roleUser = roleManager.Roles.Where(m => m.Name.Equals(roles[0]));
                foreach (var item in roleUser)
                {
                    _userRoles.Add(new SelectListItem
                    {
                        Value = item.Id,
                        Text = item.Name
                    });
                }
            }
            return _userRoles;
        }
    }
}
