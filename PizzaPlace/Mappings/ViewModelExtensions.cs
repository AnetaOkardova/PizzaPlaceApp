﻿using PizzaPlace.Models;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Mappings
{
    public static class ViewModelExtensions
    {
        public static Order ToModel(this OrderViewModel orderViewModel)
        {
            var order = new Order()
            {
                Name = orderViewModel.Name,
                Surname = orderViewModel.Surname,
                Address = orderViewModel.Address,
                Phone = orderViewModel.Phone,
                Message = orderViewModel.Message,
            };

            return order;
        }
        public static Subscription ToModel(this SubscriptionViewModel subscriptionViewModel)
        {
            var subscription = new Subscription()
            {
                Email = subscriptionViewModel.Email
            };

            return subscription;
        }
        public static MenuItem ToModel(this MenuItemView menuItem)
        {
            return new MenuItem()
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Currency = menuItem.Currency,
                ImageUrl = menuItem.ImageUrl,
                Slug = menuItem.Slug
            };
        }
    }
}
