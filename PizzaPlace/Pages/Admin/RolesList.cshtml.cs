using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaPlace.Pages.Admin
{
    public class RolesListModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesListModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public List<IdentityRole> RolesList { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet(string message = null, string errorMessage = null)
        {
            if (message != null)
            {
                Message = message;
            }
            if (errorMessage != null)
            {
                ErrorMessage = errorMessage;
            }
            var roles = _roleManager.Roles.ToList();
            if (roles == null)
            {
                Message = "There are no roles to show";
            }
            else
            {
                RolesList = roles;
            }
        }
        public async Task<IActionResult> OnGetDeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                Message = $"There is no role with {id}.";
                OnGet();
                return Page();
            }
            else
            {
                await _roleManager.DeleteAsync(role);
                OnGet();
                return Page();
            }
        }
    }
}
