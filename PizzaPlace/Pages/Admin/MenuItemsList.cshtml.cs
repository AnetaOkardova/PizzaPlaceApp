using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin
{
    public class MenuItemsListModel : PageModel
    {
        private readonly IMenuItemsService _menuItemsService;

        public MenuItemsListModel(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService;
        }
        public List<MenuItemsListViewModel> MenuItems { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            var menuItems = _menuItemsService.GetAll();
            MenuItems = menuItems.Select(x => x.ToMenuItemsListViewModel()).ToList();
        }
        public IActionResult OnGetDelete(int id)
        {
            var menuItem = _menuItemsService.GetById(id);
            if (menuItem == null)
            {
                Message = "There is no item with such Id";
                OnGet();
                return Page();
            }
            else
            {
                _menuItemsService.Delete(menuItem);
                OnGet();
                return Page();
            }
        }
        
    }
}
