using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Usuarios.Library;
using Usuarios.Models;

namespace Usuarios.Controllers
{
    public class HomeController : Controller
    {
        LUsuarios _usuarios;

        IServiceProvider _serviceProvider;
        //public HomeController(IServiceProvider serviceProvider)
        //{
        //    _serviceProvider = serviceProvider;
        //}

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _usuarios = new LUsuarios(userManager, signInManager, roleManager);
        }

        public async Task<IActionResult> Index()
        {
            await CreateRoles(_serviceProvider);

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var listObject = await _usuarios.UserLogin(model.Input.Email, model.Input.Password);
            }
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] rolesName = { "Admin", "User" };

            foreach (var item in rolesName)
            {
                bool roleExist = await roleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
            //IdentityUser
            var user = await userManager.FindByIdAsync("dfc2f3d7-5029-4caf-95e5-6d71b0c213a0");

            try
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
