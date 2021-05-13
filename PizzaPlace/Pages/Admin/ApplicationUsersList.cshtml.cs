using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin
{
    public class ApplicationUsersListModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUsersListModel(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public List<ApplicationUsersListViewModel> UsersList { get; set; } = new List<ApplicationUsersListViewModel>();
        public List<IdentityRole> Roles { get; set; }

        public string Message { get; set; }


        public async Task OnGet()
        {
            var users = _userManager.Users.ToList();
            var usersToView = new List<ApplicationUsersListViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var convertedRoles = new List<string>();
                if (roles != null)
                {
                    foreach (var role in roles)
                    {
                        string newRole = role.ToString();
                        convertedRoles.Add(newRole);
                    }
                }
                var userViewModel = user.ToApplicationUsersListViewModel();
                userViewModel.Roles = convertedRoles;
                usersToView.Add(userViewModel);
            }
            UsersList = usersToView;
            Roles = _roleManager.Roles.ToList();
        }
        public async Task<IActionResult> OnGetDeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetRemoveRole(string roleName, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, roleName);
            return RedirectToPage();
        }
        public async Task<IActionResult> OnGetAddRole(string roleName, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, roleName);
            return RedirectToPage();
        }
    }
}
