using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaPlace.Mappings;
using PizzaPlace.Services.Interfaces;
using PizzaPlace.ViewModels;

namespace PizzaPlace.Pages.Admin.Modify.Offer
{
    public class CreateModel : PageModel
    {
        private readonly IOffersService _offersService;

        public CreateModel(IOffersService offersService)
        {
            _offersService = offersService;
        }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public OfferListViewModel Offer { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost(OfferListViewModel offer)
        {
            if (ModelState.IsValid)
            {
                var domainModel = offer.ToModel();
                var response = _offersService.Create(domainModel);
                if (!response.IsSuccessfull)
                {
                    ErrorMessage = response.Message;
                    return Page();
                }

            }
            return RedirectToPage("/Admin/OffersList");
        }
    }
}
