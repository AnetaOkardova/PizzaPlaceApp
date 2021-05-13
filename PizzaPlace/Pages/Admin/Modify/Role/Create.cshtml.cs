using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaPlace.Pages.Admin.Modify.Role
{
    public class CreateModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public string MessageToSend { get; set; }
        public string ErrorMessageToSend { get; set; }

        public IdentityRole Role { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string roleName)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.FindByNameAsync(roleName);
                if(roleExists != null)
                {
                    ErrorMessageToSend = $"There is already a role with name {roleName}.";
                    return RedirectToPage("/Admin/RolesList", new { ErrorMessage = ErrorMessageToSend });
                }
                var role = new IdentityRole();
                role.Name = roleName;
                role.NormalizedName = roleName.ToUpper();

                await _roleManager.CreateAsync(role);
                MessageToSend = $"The role {roleName} has been successfully created";
            }
            else
            {
                ErrorMessageToSend = $"There has been a mistake. Please try again later.";
                return RedirectToPage("/Admin/RolesList", new { ErrorMessage = ErrorMessageToSend });
            }
            return RedirectToPage("/Admin/RolesList", new { Message = MessageToSend});
        }
    }
}
