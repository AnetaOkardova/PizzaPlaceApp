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
    public class ModifyModel : PageModel
    {
        private readonly IOffersService _offersService;

        public ModifyModel(IOffersService offersService)
        {
            _offersService = offersService;
        }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public OfferListViewModel Offer { get; set; }

        public void OnGet(int id)
        {
            var menuItem = _offersService.GetById(id);
            if (menuItem == null)
            {
                ErrorMessage = $"There is no offer with ID: {id}";
            }
            else
            {
                Offer = menuItem.ToOfferListViewModel();
            }
        }
        public IActionResult OnPost(OfferListViewModel offer)
        {
            if (ModelState.IsValid)
            {
                var domainModel = offer.ToModel();
                var response = _offersService.Update(domainModel);
                if (response.IsSuccessfull)
                {
                    return RedirectToPage("/Admin/OffersList");
                }
                else
                {
                    ErrorMessage = response.Message;
                    return Page();
                }
            }
            return Page();
        }
    }
}
