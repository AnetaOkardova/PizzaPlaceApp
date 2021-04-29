using PizzaPlace.Models;
using PizzaPlace.Models.DtoModels;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services.Interfaces
{
    public interface IOrdersService
    {
        void Create(Order order);
        Order GetById(int id);
        List<Order> GetAll();
        void SetDelivered(Order order);
        void SetProcessed(Order order);
    }
}
