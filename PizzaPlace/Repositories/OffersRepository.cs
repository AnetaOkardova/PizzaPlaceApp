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
            _context = context;
        }

        public List<Offer> GetAllValid()
        {
            return _context.Offers.Where(x=>x.ValidUntil.Date>=DateTime.Now.Date).ToList();
        }

        public List<Offer> GetAll()
        {
            return _context.Offers.ToList();
        }

        public Offer GetById(int id)
        {
           return _context.Offers.FirstOrDefault(x=>x.Id == id);
        }

        public void Delete(Offer offer)
        {
            _context.Remove(offer);
            _context.SaveChanges();
        }

        public bool CheckIfExists(Offer offer, string title)
        {
            bool exists = true;
            if (offer != null)
            {
                exists = _context.Offers.Any(x => x.Title == offer.Title);
            }

            if (title != null)
            {
                exists = _context.Offers.Any(x => x.Title == title);
            }
            return exists;
        }

        public void Create(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        public void Update(Offer offer)
        {
            _context.Offers.Update(offer);
            _context.SaveChanges(); ;
        }
    }
}
