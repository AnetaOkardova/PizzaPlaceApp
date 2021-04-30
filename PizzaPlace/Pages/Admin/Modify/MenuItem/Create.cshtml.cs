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
    public class CreateModel : PageModel
    {
        private readonly IMenuItemsService _menuItemsService;

        public CreateModel(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService;
        }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public MenuItemView MenuItem { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost(MenuItemView menuItem)
        {
            if (ModelState.IsValid)
            {
                var domainModel = menuItem.ToModel();
                var response = _menuItemsService.Create(domainModel);
                if (!response.IsSuccessfull)
                {
                    ErrorMessage = response.Message;
                    return Page();
                }

            }
            return RedirectToPage("/Admin/MenuItemsList");
        }
    }
}
