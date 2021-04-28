using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Repositories
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly PizzaPlaceDbContext _context;

        public SubscriptionsRepository(PizzaPlaceDbContext context)
        {
            _context = context;
        }
        public void Add(Subscription subscription)
        {
            subscription.DateSubscribed = DateTime.Now;
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
        }

        public bool CheckIfExists(string email)
        {
            return _context.Subscriptions.Any(x => x.Email.ToUpper() == email.ToUpper());
        }
    }
}
