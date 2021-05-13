using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PizzaPlace.Pages.Admin.Modify.Role
{
    public class ModifyModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ModifyModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public string MessageToSend { get; set; }
        public string ErrorMessage { get; set; }

        public IdentityRole Role { get; set; }

        public async Task OnGet(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ErrorMessage = $"There is no role with {id}.";
            }
            else
            {
                Role = role;
            }
        }
        public async Task<IActionResult> OnPost(IdentityRole identityRole)
        {
            if (ModelState.IsValid)
            {
                var getRoleById = await _roleManager.FindByIdAsync(identityRole.Id);
                if (getRoleById == null)
                {
                    ErrorMessage = $"There is no role with id {identityRole.Id}.";
                    return Page();
                }
                else
                {
                    getRoleById.Name = identityRole.Name;
                    getRoleById.NormalizedName = identityRole.Name.ToUpper();
                    await _roleManager.UpdateAsync(getRoleById);
                    MessageToSend = "The role has been successfully updated.";
                    return RedirectToPage("/Admin/RolesList", new { Message = MessageToSend });
                };
            }
            return Page();
        }
    }
}
