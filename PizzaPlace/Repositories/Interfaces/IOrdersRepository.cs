using PizzaPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        Order GetById(int id);
        List<Order> GetAll();
        List<Order> GetByStatus(OrderStatus orderStatus);
        void SetStatus(Order order);
    }
}
