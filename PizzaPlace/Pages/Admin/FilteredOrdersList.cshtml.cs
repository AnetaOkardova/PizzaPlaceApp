using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Models;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin
{
    [Authorize(Roles = "Cook, DeliveryPerson")]
    public class FilteredOrdersListModel : PageModel
    {
        private readonly IOrdersService _ordersService;
        public FilteredOrdersListModel(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public List<OrdersListViewModel> OrdersList { get; set; }
        public string Message { get; set; }

        public IActionResult OnGetProcessed()
        {
            var processedOrders = _ordersService.GetByStatus(OrderStatus.Processed);
            if (processedOrders.Count == 0)
            {
                Message = "There are no processed orders at this time";
                return Page();
            }
            else
            {
                OrdersList = processedOrders.Select(x => x.ToOrdersListViewModel()).ToList();
                return Page();
            }
        }
        public IActionResult OnGetInProgress()
        {
            var InProgressOrders = _ordersService.GetByStatus(OrderStatus.InProgress);
            if (InProgressOrders.Count == 0)
            {
                Message = "There are no in progress orders at this time";
                return Page();
            }
            else
            {
                OrdersList = InProgressOrders.Select(x => x.ToOrdersListViewModel()).ToList();
                return Page();
            }
        }

        public IActionResult OnGetSetDelivered(int id)
        {
            var order = _ordersService.GetById(id);
            if (order == null)
            {
                Message = "There is no order with such Id";
                OnGetProcessed();
                return Page();
            }
            else
            {
                _ordersService.SetStatus(order);
                OnGetProcessed();
                return Page();
            }

        }
        public IActionResult OnGetSetProcessed(int id)
        {
            var order = _ordersService.GetById(id);
            if (order == null)
            {
                Message = "There is no order with such Id";
                OnGetInProgress();
                return Page();
            }
            else
            {
                _ordersService.SetStatus(order);
                OnGetInProgress();
                return Page();
            }
        }
    }
}
