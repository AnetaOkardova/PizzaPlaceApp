using PizzaPlace.Models;
using PizzaPlace.Models.DtoModels;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services.Interfaces
{
    public interface IMenuItemsService
    {
        List<MenuItem> GetAll();
        MenuItem GetById(int id);
        MenuItem GetBySlug(string slug);
        StatusModel Update(MenuItem menuItem);
        void Delete(MenuItem menuItem);
        StatusModel Create(MenuItem domainModel);
    }
}
