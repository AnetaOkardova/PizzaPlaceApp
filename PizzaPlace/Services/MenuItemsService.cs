using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Models.DtoModels;
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

        public StatusModel Create(MenuItem menuItem)
        {
            var response = new StatusModel();
            bool ifExists = _menuItemsRepositorty.CheckIfExists(null, menuItem.Title);
            if (ifExists)
            {
                response.IsSuccessfull = false;
                response.Message = $"There already is a menu item with title {menuItem.Title}";
            }
            else
            {
                menuItem.DateCreated = DateTime.Now;
                menuItem.Slug = menuItem.Title.GenerateSlug();
                _menuItemsRepositorty.Create(menuItem);
            }
            return response;

        }

        public void Delete(MenuItem menuItem)
        {
            _menuItemsRepositorty.Delete(menuItem);
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

        public StatusModel Update(MenuItem menuItem)
        {
            var response = new StatusModel();
            var menuItemToModify = _menuItemsRepositorty.GetById(menuItem.Id);
            if (menuItemToModify != null)
            {
                menuItemToModify.Slug = menuItem.Title.GenerateSlug();

                var checkIfExists = _menuItemsRepositorty.CheckIfExists(menuItemToModify, null) ;
                if (checkIfExists)
                {
                    response.IsSuccessfull = false;
                    response.Message = $"There is already a manu item with title {menuItem.Title}";
                }
                else
                {
                    menuItemToModify.Title = menuItem.Title;
                    menuItemToModify.ImageUrl = menuItem.ImageUrl;
                    menuItemToModify.Price = menuItem.Price;
                    menuItemToModify.Currency = menuItem.Currency;
                    menuItemToModify.Description = menuItem.Description;
                    menuItemToModify.DateModified = DateTime.Now;
                    menuItemToModify.Slug = menuItem.Title.GenerateSlug();
                    _menuItemsRepositorty.Update(menuItemToModify);
                    response.Message = $"The menu item with ID {menuItemToModify.Id} has been successfully updated.";


                }
            }
            return response;
        }
    }
}
