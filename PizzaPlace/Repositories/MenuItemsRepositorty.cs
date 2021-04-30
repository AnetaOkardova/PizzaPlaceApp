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

        public void Delete(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }
        public void Create(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }
        public List<MenuItem> GetAll()
        {
            return _context.MenuItems.ToList();
        }

        public MenuItem GetById(int id)
        {
            return _context.MenuItems.FirstOrDefault(x=> x.Id == id);
        }

        public MenuItem GetBySlug(string slug)
        {
            return _context.MenuItems.FirstOrDefault(x => x.Slug.ToLower() == slug.ToLower());
        }

        public void Update(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges(); 
        }

        public bool CheckIfExists(MenuItem menuItem, string title)
        {
            bool exists = true;
            if(menuItem != null)
            {
                exists = _context.MenuItems.Any(x => x.Slug == menuItem.Slug);
            }
            
            if(title != null)
            {
                exists = _context.MenuItems.Any(x => x.Title == title);
            }

            return exists;
        }
    }
}
