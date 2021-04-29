using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOffersService _offersService;
        private readonly ISubscriptionsService _subscriptionsService;

        public IndexModel(IOffersService offersService, ISubscriptionsService subscriptionsService)
        {
            _offersService = offersService;
            _subscriptionsService = subscriptionsService;
        }

        [BindProperty]
        public List<OfferViewModel> Offers { get; set; }

        public string Message { get; set; }
        [BindProperty]
        public SubscriptionViewModel SubscriptionEmail { get; set; }
        public string MessageAboutSubscribing { get; set; }

        public void OnGet()
        {
            var offers = _offersService.GetAllValid();
            if (offers == null)
            {
                Message = "There are no active offers at this time";
            }
            else
            {
                Offers = offers.Select(x => x.ToOfferViewModel()).ToList();
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var subscription = SubscriptionEmail.ToModel();
                var isSuccessfull = _subscriptionsService.Create(subscription);
                if (isSuccessfull)
                {
                    OnGet();
                    return Page();
                }
                else
                {
                    OnGet();
                    MessageAboutSubscribing = $"There is already a subscription with the email: {subscription.Email}";
                    return Page();
                }
            }
            return Page();
        }
    }
}
