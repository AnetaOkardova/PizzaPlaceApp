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

namespace PizzaPlace.Pages.Admin
{
    [Authorize]
    public class OffersListModel : PageModel
    {
        private readonly IOffersService _offersService;

        public OffersListModel(IOffersService offersService)
        {
            _offersService = offersService;
        }
        public List<OfferListViewModel> OffersList { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            var offers = _offersService.GetAll();
            if(offers == null)
            {
                Message = "There are no offers to show";
            }
            else
            {
                OffersList = offers.Select(x => x.ToOfferListViewModel()).ToList();
            }
        }
        public IActionResult OnGetDelete(int id)
        {
            var offer = _offersService.GetById(id);
            if (offer == null)
            {
                Message = "There is no item with such Id";
                OnGet();
                return Page();
            }
            else
            {
                _offersService.Delete(offer);
                OnGet();
                return Page();
            }
        }
    }
}
