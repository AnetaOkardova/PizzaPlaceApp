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

        public IndexModel(IOffersService offersService)
        {
            _offersService = offersService;
        }


        public List<OfferViewModel> Offers { get; set; }
        public string Message { get; set; }


        public void OnGet()
        {
            //var offers = _offersService.GetAllValid();
            //if (offers == null)
            //{
            //    Message = "There are no active offers at this time";
            //}
            //Offers = offers.Select(x => x.ToOfferViewModel()).ToList();

            Offers = new List<OfferViewModel>()
            {
                new OfferViewModel()
                {
                    Title = "Naslov",
                    Description = "With supporting text below as a natural lead-in to additional content.",
                    ValidUntil = DateTime.Now.AddDays(15)
                },
                new OfferViewModel()
                {
                    Title = "Naslov2",
                    Description = "With supporting text below as a natural lead-in to additional content.",
                    ValidUntil = DateTime.Now.AddDays(5)
                },
                new OfferViewModel()
                {
                    Title = "Naslov3",
                    Description = "With supporting text below as a natural lead-in to additional content.",
                    ValidUntil = DateTime.Now.AddDays(25)
                }
            };
        }
    }
}
