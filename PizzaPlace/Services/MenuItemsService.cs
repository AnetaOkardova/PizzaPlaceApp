using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services
{
    
    public class MenuItemsService : IMenuItemsService
    {
        private readonly IMenuItemsRepositorty _menuItemsRepositorty;

        public MenuItemsService(IMenuItemsRepositorty menuItemsRepositorty)
        {
            _menuItemsRepositorty = menuItemsRepositorty;
        }
      

        public List<MenuItem> GetAll()
        {
           return _menuItemsRepositorty.GetAll();
        }

        public MenuItem GetById(int id)
        {
            return _menuItemsRepositorty.GetById(id);
        }

        public MenuItem GetBySlug(string slug)
        {
           return _menuItemsRepositorty.GetBySlug(slug);
        }
    }
}
