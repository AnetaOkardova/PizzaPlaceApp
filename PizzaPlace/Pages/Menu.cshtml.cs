using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IMenuItemsService _menuItemsService;

        public MenuModel(IMenuItemsService MenuItemsService)
        {
            _menuItemsService = MenuItemsService;
        }
        public List<MenuItemView> MenuItems { get; set; }
        public void OnGet()
        {
            var allItems = _menuItemsService.GetAll();
            MenuItems = allItems.Select(x => x.ToMenuItemView()).ToList();
        }
    }
}
