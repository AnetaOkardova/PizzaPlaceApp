using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin
{
    public class OrdersListModel : PageModel
    {
        private readonly IOrdersService _ordersService;

        public OrdersListModel(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public List<OrdersListViewModel> OrdersList { get; set; }
        public void OnGet()
        {
            var orders = _ordersService.GetAll();
            OrdersList = orders.Select(x => x.ToOrdersListViewModel()).ToList();

        }

    }
}
