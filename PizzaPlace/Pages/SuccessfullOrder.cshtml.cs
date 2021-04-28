using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages
{
    public class SuccessfullOrderModel : PageModel
    {
        private readonly ISubscriptionsService _subscriptionsService;

        public SuccessfullOrderModel(ISubscriptionsService subscriptionsService)
        {
            _subscriptionsService = subscriptionsService;
        }
        [BindProperty]
        public SubscriptionViewModel SubscriptionEmail { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var subscription = SubscriptionEmail.ToModel();
                var isSuccessfull = _subscriptionsService.Create(subscription);
                if (isSuccessfull)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    Message = $"There is already a subscription with the email: {subscription.Email}";
                    return Page();
                }
            }
            return Page();
        }
    }
}
