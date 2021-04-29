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
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void Create(Order order)
        {
            order.Status = OrderStatus.InProgress;
            _ordersRepository.Add(order);
        }
        //function slugify(text)
        //{
        //    return text.toString().toLowerCase()
        //      .replace(/\s +/ g, '-')           // Replace spaces with -
        //      .replace(/[^\w\-] +/ g, '')       // Remove all non-word chars
        //      .replace(/\-\-+/ g, '-')         // Replace multiple - with single -
        //      .replace(/ ^-+/, '')             // Trim - from start of text
        //      .replace(/ -+$/, '');            // Trim - from end of text
        //}
        private string Slugify(string name)
        {
            return name.ToLower();
                //.Replace(/\s +/ g, '-')
                //.Replace(/[^\w\-] +/ g, '')
                //.Replace(/\-\-+/ g, '-')
                //.Replace(/ ^-+/, '')
                //.Replace(/ -+$/, '');
        }

        public Order GetById(int id)
        {
            return _ordersRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return _ordersRepository.GetAll();
        }

        public void SetDelivered(Order order)
        {
            order.Status = OrderStatus.Delivered;
            _ordersRepository.Update(order);
        }

        public void SetProcessed(Order order)
        {
            order.Status = OrderStatus.Processed;
            _ordersRepository.Update(order);
        }
    }
}
