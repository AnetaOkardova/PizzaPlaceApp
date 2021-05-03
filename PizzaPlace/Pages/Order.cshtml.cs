using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages
{
    [Authorize]
    public class OrderModel : PageModel
    {
        private readonly IOrdersService _ordersService;

        public OrderModel(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [BindProperty]
        public OrderViewModel Order { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newOrder = Order.ToModel();
                _ordersService.Create(newOrder);
                return RedirectToPage("SuccessfullOrder");
            }
            return Page();
        }
    }
}
