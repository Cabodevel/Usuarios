using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Usuarios.Models;

namespace Usuarios.Library
{
    public class ListObject
    {
        public string Description, code;

        public UserData _userData;
        public IdentityError _IdentityError;
        public UsersRoles _usersRoles;
        public List<SelectListItem> _userRoles;
        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;

        public List<object[]> dataList = new List<object[]>();
    }
}
