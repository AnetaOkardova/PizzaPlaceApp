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
    public class TrackOrderModel : PageModel
    {
        private readonly IOrdersService _ordersService;

        public TrackOrderModel(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public OrderViewModel Order { get; set; }
        public void OnGet()
        {
        }
    }
}
