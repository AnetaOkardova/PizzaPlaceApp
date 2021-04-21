using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private PizzaPlaceDbContext _context { get; set; }
        public OffersRepository(PizzaPlaceDbContext context)
        {
        }

        public List<Offer> GetAllValid()
        {
            return _context.Offers.Where(x=>x.ValidUntil>=DateTime.Now).ToList();
        }
    }
}
