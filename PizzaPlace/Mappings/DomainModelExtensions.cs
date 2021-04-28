using PizzaPlace.Models;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Mappings
{
    public static class DomainModelExtensions
    {
        public static OfferViewModel ToOfferViewModel(this Offer offer)
        {
            return new OfferViewModel()
            {
                Title = offer.Title,
                Description = offer.Description,
                ValidUntil = offer.ValidUntil
            };
        }

        public static MenuItemView ToMenuItemView(this MenuItem menuItem)
        {
            return new MenuItemView()
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
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Name = order.Name,
                Surname = order.Surname,
                Address = order.Address,
                Phone = order.Phone,
                Message = order.Message,
            };
        }
    }
}
