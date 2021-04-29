using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private PizzaPlaceDbContext _context { get; set; }
        public OrdersRepository(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            order.DateCreated = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
}
