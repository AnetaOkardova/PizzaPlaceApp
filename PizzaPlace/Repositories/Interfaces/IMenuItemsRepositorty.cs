using PizzaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories.Interfaces
{
    public interface IMenuItemsRepositorty
    {
        List<MenuItem> GetAll();
        MenuItem GetById(int id);
        MenuItem GetBySlug(string slug);
        void Update(MenuItem menuItem);
        void Delete(MenuItem menuItem);
        bool CheckIfExists(MenuItem menuItem, string title);
        void Create(MenuItem menuItem);
    }
}
