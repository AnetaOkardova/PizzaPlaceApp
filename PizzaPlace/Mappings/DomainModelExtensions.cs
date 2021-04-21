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
    }
}
