using PizzaPlace.Models;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public static OfferListViewModel ToOfferListViewModel(this Offer offer)
        {
            return new OfferListViewModel()
            {
                Id = offer.Id,
                Title = offer.Title,
                Description = offer.Description,
                ValidUntil = offer.ValidUntil,
                DateCreated = offer.DateCreated
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
        public static OrdersListViewModel ToOrdersListViewModel(this Order order)
        {
            return new OrdersListViewModel()
            {
                Id = order.Id,
                Name = order.Name,
                Surname = order.Surname,
                Address = order.Address,
                Phone = order.Phone,
                Message = order.Message,
                Status = order.Status.ToString(),
                DateCreated = order.DateCreated
            };
        }
        public static MenuItemsListViewModel ToMenuItemsListViewModel(this MenuItem menuItem)
        {
            return new MenuItemsListViewModel()
            {
                Id = menuItem.Id,
                Title = menuItem.Title,
                Description = menuItem.Description,
                Price = menuItem.Price,
                Currency = menuItem.Currency,
                ImageUrl = menuItem.ImageUrl,
                DateCreated = menuItem.DateCreated,
                Slug = menuItem.Slug
            };
        }
        public static string GenerateSlug(this string phrase)
        {
            string str = phrase.ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }
        public static ApplicationUsersListViewModel ToApplicationUsersListViewModel(this ApplicationUser applicationUser)
        {
            return new ApplicationUsersListViewModel()
            {
                Id = applicationUser.Id,
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                PhoneNumber = applicationUser.PhoneNumber,
                Name = applicationUser.Name,
                Surname = applicationUser.Surname,
                Address = applicationUser.Address,
            };
        }
    }
}
