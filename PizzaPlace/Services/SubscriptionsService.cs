using PizzaPlace.Models;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Services
{
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly ISubscriptionsRepository _subscriptionsRepository;

        public SubscriptionsService(ISubscriptionsRepository subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }

        public bool Create(Subscription subscription)
        {
            var IfExists = _subscriptionsRepository.CheckIfExists(subscription.Email);
            if (!IfExists)
            {
                _subscriptionsRepository.Add(subscription);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
