using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin.Modify.MenuItem
{
    public class ModifyModel : PageModel
    {
        private readonly IMenuItemsService _menuItemsService;

        public ModifyModel(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService;
        }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public MenuItemView MenuItem { get; set; }

        public void OnGet(int id)
        {
            var menuItem = _menuItemsService.GetById(id);
            if(menuItem == null)
            {
                ErrorMessage = $"There is no menu item with ID: {id}";
            }
            else
            {
                MenuItem = menuItem.ToMenuItemView();
            }
        }
        public IActionResult OnPost(MenuItemView menuItem)
        {
            if (ModelState.IsValid)
            {
                var domainModel = menuItem.ToModel();
                var response = _menuItemsService.Update(domainModel);
                if (response.IsSuccessfull)
                {
                    return RedirectToPage("/Admin/MenuItemsList");
                }
                else
                {
                    ErrorMessage = response.Message;
                    return Page();
                }
            }
            return Page();
        }
    }
}
