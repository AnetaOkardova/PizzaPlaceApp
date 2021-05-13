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
            //order.Id = int.Parse(Guid.NewGuid().ToString());
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

        public List<Order> GetByStatus(OrderStatus orderStatus)
        {
            return _context.Orders.Where(x => x.Status == orderStatus).ToList();
        }
        public void SetStatus(Order order)
        {
            if (order.Status == OrderStatus.Processed)
            {
                order.Status = OrderStatus.Delivered;
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
            if (order.Status == OrderStatus.InProgress)
            {
                order.Status = OrderStatus.Processed;
                _context.Orders.Update(order);
                _context.SaveChanges();
            }
            
        }
    }
}
