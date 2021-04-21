using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories
{
    public class MenuItemsRepositorty : IMenuItemsRepositorty
    {
        private readonly PizzaPlaceDbContext _context;

        public MenuItemsRepositorty(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }
    }
}
