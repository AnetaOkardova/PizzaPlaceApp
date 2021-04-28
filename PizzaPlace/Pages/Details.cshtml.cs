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
    public class DetailsModel : PageModel
    {
        private readonly IMenuItemsService _menuItemsService;

        public DetailsModel(IMenuItemsService MenuItemsService)
        {
            _menuItemsService = MenuItemsService;
        }
        public MenuItemView MenuItem { get; set; }
        public string Message { get; set; }
        public void OnGet(string slug)
        {
            var menuItem = _menuItemsService.GetBySlug(slug);

            if(menuItem == null)
            {
                Message = $"There is no item with name {slug}";
            }
            else{
                MenuItem = menuItem.ToMenuItemView();
            }
        }
    }
}
